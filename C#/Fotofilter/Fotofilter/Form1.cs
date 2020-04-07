using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Fotofilter
{
    public partial class mainForm : Form
    {
        //saves the original image as a safestate
        private static Bitmap OriginalImage;

        //the cache for edits
        public static List<Bitmap> editHistory = new List<Bitmap>();
        public static int currentImage = 0;

        //for checking if you saved the image before closing so it doesn't get lost
        private bool hasSaved = true;

        //the standard brush color for the drawing tool
        public Color brushColor = Color.Black;
        private bool painting = false;

        //the slider used for the brightness shifter
        BrightSlide BrightSlide = new BrightSlide();

        public mainForm()
        {
            InitializeComponent();
            openImage.Title = "Select an image...";
            openImage.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF";
            saveImage.Filter = openImage.Filter;
            openImage.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            saveImage.InitialDirectory = openImage.InitialDirectory;

            //draws the color picture for the color select
            Bitmap logo = new Bitmap(16, 16);
            for (int y = 0; y < logo.Height; y++)
            {
                for (int x = 0; x < logo.Width; x++)
                {
                    logo.SetPixel(x, y, brushColor);
                }
            }
            drawColorSelection.Image = logo;

        }

        #region General functions
        private void CloseApp(object sender, EventArgs e)
        {
            if (!hasSaved)
            {
                DialogResult exit = MessageBox.Show("Are you sure you want to exit?\r\nContent has not been saved.", "Exit dialog", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (exit == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }

        }

        private void OpenAbout(object sender, EventArgs e)
        {
            MessageBox.Show("This program was made by Gabriel Mattsson as a project for his programming course and includes a variety of different image filters\n\rSort: has 2 features; shade sort sorts all the pixels after how bright they are and color sort sorts them from red to green to blue.", "About Page", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OpenImage(object sender, EventArgs e)
        {
            //Open image logic
            if (openImage.ShowDialog() == DialogResult.OK)
            {
                editHistory.Clear();
                OriginalImage = new Bitmap(openImage.FileName);
                editHistory.Add(OriginalImage);
                mainForm.ActiveForm.Width = OriginalImage.Width;
                mainForm.ActiveForm.Height = OriginalImage.Height;
                pbBild.Image = OriginalImage;
                currentImage = -1;
                // sets picturebox to the image size
                pbBild.Width = OriginalImage.Width;
                pbBild.Height = OriginalImage.Height;
            }
        }

        private Bitmap GetCurrentImage()
        {
            //if you've undone and thus stops weird image stacking because add puts the image at the end of the list
            if (currentImage < editHistory.Count - 1)
            {
                for (int i = 1; currentImage > editHistory.Count() - i; i++)
                {
                    editHistory.RemoveAt(editHistory.Count() - i);
                }

                //sets currentImage to the current image position / last position in the array as 
                //currentImage = editHistory.Count - 1;
            }

            hasSaved = false;
            editHistory.Add(new Bitmap(pbBild.Image));
            currentImage = editHistory.Count - 1;
            return new Bitmap(editHistory[currentImage]);
        }

        private void ImageSaveAs(object sender, EventArgs e)
        {

            if (saveImage.ShowDialog() == DialogResult.OK)
            {
                //Available formats: *.BMP; *.JPG; *.GIF,*.PNG,*.TIFF
                //saves image in different formats depending on which you want
                //default format is bitmap
                //system gotten from 
                //https://stackoverflow.com/questions/11055258/how-to-use-savefiledialog-for-saving-images-in-c


                ImageFormat format;
                //gets the file format you want to save to and then sets that format
                string ext = System.IO.Path.GetExtension(saveImage.FileName).ToLower();
                switch (ext)
                {
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;

                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;

                    case ".gif":
                        format = ImageFormat.Gif;
                        break;

                    case ".png":
                        format = ImageFormat.Png;
                        break;

                    case ".tiff":
                        format = ImageFormat.Tiff;
                        break;

                    default:
                        format = ImageFormat.Bmp;
                        break;
                }

                Bitmap picture = new Bitmap(pbBild.Image);
                picture.Save(saveImage.FileName, format);
                hasSaved = true;
            }

        }

        private void ResetImage(object sender, EventArgs e)
        {
            pbBild.Image = editHistory[0];
        }

        private void Undo(object sender, EventArgs e)
        {
            //and every time this function gets called it goes back one step 

            //how to work: always set the current bitmap to be the last one in the list, when edited
            //when ctrl + z then increase the displacement by 1 

            //problems: the undo isntead make the image turn into the original and not the one that is one step back
            //problems: current image is being weird cuz it should be decreased before the picture is set, not before
            //steps back in the image history
            if (currentImage > 0)
            {
                currentImage--;

                pbBild.Image = editHistory[currentImage];
            }

        }

        private void Redo(object sender, EventArgs e)
        {

            //weird interaction when undoing and redoing 
            if (currentImage < editHistory.Count - 1)
            {
                currentImage++;
                pbBild.Image = editHistory[currentImage];
            }
        }

        private int RGBClamp(double value)
        {

            return Convert.ToInt32(Math.Min(Math.Max(value, 0), 255));

        }

        private int Clamp(int min, int value, int max)
        {
            return Math.Min(Math.Max(value, min), max);
        }

        private void CopyToClipboard(object sender, EventArgs e)
        {
            Clipboard.SetImage(pbBild.Image);

        }

        #endregion

        #region Manipulate image

        //inför lossless operations: Alla filter man gör läggs på en lista, sedan så tar man grundbilden och filtrerar den vidare genom listan, detta gör då att brightness t.ex fungerar bättre
        //tror det kan vara såhär de gör på photoshop när de använder layers
        private void DemonGrainImageFilter(object sender, EventArgs e)
        {

            //gets the current iamge and other necessities
            Bitmap picture = GetCurrentImage();
            Random rng = new Random();

            // gets all colours and puts then in an array in order top left to right 
            Color[] allPixels = new Color[picture.Width * picture.Height];

            //which pixel it is on when it is saving it
            int whichPixel = 0;

            for (int y = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++, whichPixel++)
                {
                    allPixels[whichPixel] = picture.GetPixel(x, y);
                }
            }

            foreach (Color pixel in allPixels)
            {
                int xPos = rng.Next(0, picture.Width);
                int yPos = rng.Next(0, picture.Height);

                picture.SetPixel(xPos, yPos, pixel);
            }

            pbBild.Image = picture;
        }

        private void ShadeSortFilter(object sender, EventArgs e)
        {
            //Problems: When the shades are sorted the heap sort leaves weird artifacting in the image
            //take any image and then sort the pixels by brightness for a cool visualisation

            Bitmap picture = GetCurrentImage();

            Color[] allPixels = new Color[picture.Width * picture.Height];
            int[] colorValue = new int[allPixels.Count()];

            for (int y = 0, whichPixel = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++, whichPixel++)
                {
                    allPixels[whichPixel] = picture.GetPixel(x, y);
                }
            }

            //theory: using reference with heap sort is the most memory efficent because it doesn't create a new array and heapsort is an in-place sorting algorithm which makes it use even less space
            ShadeHeapSort(ref allPixels);

            //draws image
            for (int y = 0, whichPixel = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++, whichPixel++)
                {
                    picture.SetPixel(x, y, allPixels[whichPixel]);
                }
            }

            pbBild.Image = picture;
        }

        #region ShadeHeapSort
        static void ShadeHeapSort(ref Color[] pixels)
        {
            //when the input is already sorted then it does some weird displacement so this is to stop that
            for (int i = 0; true; i++)
            {
                if (i == pixels.Length - 1)
                {
                    //it has gone through the array and doesn't need sorting
                    return;
                }

                if (pixels[i + 1].GetBrightness() > pixels[i].GetBrightness())
                {
                    //it found a discrepancy and thus proceeds to sorting
                    break;
                }
            }


            int n = pixels.Length;

            for (int i = (n / 2) - 1; i >= 0; i--)
            {
                ShadeHeapify(ref pixels, n, i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                Color tmp = pixels[i];
                pixels[i] = pixels[0];
                pixels[0] = tmp;

                ShadeHeapify(ref pixels, i, 0);
            }
        }

        static void ShadeHeapify(ref Color[] pixels, int n, int i)
        {
            //gets the position of the parent and each of its children
            int largest = i;
            int leftChild = (2 * i) + 1;
            int rightChild = (2 * i) + 2;

            //checks if the siblings are larger
            if (leftChild < n && pixels[leftChild].GetBrightness() < pixels[largest].GetBrightness())
            {
                largest = leftChild;
            }

            if (rightChild < n && pixels[rightChild].GetBrightness() < pixels[largest].GetBrightness())
            {
                largest = rightChild;
            }

            //if the largest value isn't the root of the array
            if (largest != i)
            {
                Color tmp = pixels[i];
                pixels[i] = pixels[largest];
                pixels[largest] = tmp;

                ShadeHeapify(ref pixels, n, largest);
            }

            //Martins special
            //Gör detta på den där uppe

            //int largest = i;
            //int leftChild = (2 * i) + 1;
            //int rightChild = (2 * i) + 2;

            //int leftSum = pixels[leftChild].R + pixels[leftChild].G + pixels[leftChild].B;
            //int rightSum = pixels[rightChild].R + pixels[rightChild].G + pixels[rightChild].B; // indexet låg utanför gränserna
            //int largestSum = pixels[largest].R + pixels[largest].G + pixels[largest].B;

            //if (leftChild < n && leftSum < largestSum)
            //{
            //    largest = leftChild;
            //    largestSum = pixels[largest].R + pixels[largest].G + pixels[largest].B;
            //}

            //if (rightChild < n && rightSum < largestSum)
            //{
            //    largest = rightChild;
            //    largestSum = pixels[largest].R + pixels[largest].G + pixels[largest].B;
            //}

            //if (largestSum != i)
            //{
            //    Color tmp = pixels[i];
            //    pixels[i] = pixels[largest];
            //    pixels[largest] = tmp;

            //    ShadeHeapify(ref pixels, n, largest);
            //}
        }

        #endregion

        private void ColorSortFilter(object sender, EventArgs e)
        {
            //Problems: Has issues with black so it makes it stick with the red because black has he same hue as red but bottomed brightness
            //take any image and then sort the pixels from red, green and then blue for a cool visualisation

            Bitmap picture = GetCurrentImage();
            Color[] allPixels = new Color[picture.Width * picture.Height];
            int[] colorValue = new int[allPixels.Count()];

            for (int y = 0, whichPixel = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++, whichPixel++)
                {
                    allPixels[whichPixel] = picture.GetPixel(x, y);
                }
            }

            //theory: using reference with heap sort is the most memory efficent because it doesn't create a new array and heapsort is an in-place sorting algorithm which makes it use even less space
            ColorHeapSort(ref allPixels);

            //draws image
            for (int y = 0, whichPixel = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++, whichPixel++)
                {
                    picture.SetPixel(x, y, allPixels[whichPixel]);
                }
            }

            pbBild.Image = picture;
        }

        #region ColorHeapSort
        static void ColorHeapSort(ref Color[] pixels)
        {
            //when the input is already sorted then it does some weird displacement so this is to stop that
            for (int i = 0; true; i++)
            {
                if (i == pixels.Length - 1)
                {
                    //it has gone through the array and doesn't need sorting
                    return;
                }
                if (pixels[i + 1].GetHue() < pixels[i].GetHue())
                {
                    //it found a discrepancy and thus proceeds to sorting
                    break;
                }
            }


            int n = pixels.Length;

            for (int i = (n / 2) - 1; i >= 0; i--)
            {
                ColorHeapify(ref pixels, n, i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                Color tmp = pixels[i];
                pixels[i] = pixels[0];
                pixels[0] = tmp;

                ColorHeapify(ref pixels, i, 0);
            }
        }

        static void ColorHeapify(ref Color[] pixels, int n, int i)
        {
            //gets the position of the parent and each of its children
            int largest = i;
            int leftChild = (2 * i) + 1;
            int rightChild = (2 * i) + 2;

            //checks if the siblings are larger
            if (leftChild < n && pixels[leftChild].GetHue() > pixels[largest].GetHue())
            {
                largest = leftChild;
            }

            if (rightChild < n && pixels[rightChild].GetHue() > pixels[largest].GetHue())
            {
                largest = rightChild;
            }

            //if the largest value isn't the root of the array
            if (largest != i)
            {
                Color tmp = pixels[i];
                pixels[i] = pixels[largest];
                pixels[largest] = tmp;

                ColorHeapify(ref pixels, n, largest);
            }
        }

        #endregion

        private void AbsoluteColorFilter(object sender, EventArgs e)
        {
            //Set every pixel to their absolute RGB color
            Bitmap picture = GetCurrentImage();
            Color[] allPixels = new Color[picture.Width * picture.Height];

            //gets every pixel
            for (int y = 0, whichPixel = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++, whichPixel++)
                {
                    allPixels[whichPixel] = picture.GetPixel(x, y);
                }
            }

            //processes every pixel
            for (int i = 0; i < allPixels.Count(); i++)
            {
                //red
                if (allPixels[i].GetHue() >= 0 && allPixels[i].GetHue() < 30)
                {
                    allPixels[i] = Color.Red;
                }
                //orange
                else if (allPixels[i].GetHue() >= 30 && allPixels[i].GetHue() < 60)
                {
                    allPixels[i] = Color.Orange;
                }
                //yellow
                else if (allPixels[i].GetHue() >= 60 && allPixels[i].GetHue() < 90)
                {
                    allPixels[i] = Color.Yellow;
                }
                //lime
                else if (allPixels[i].GetHue() >= 90 && allPixels[i].GetHue() < 120)
                {
                    allPixels[i] = Color.Lime;
                }
                //green
                else if (allPixels[i].GetHue() >= 120 && allPixels[i].GetHue() < 150)
                {
                    allPixels[i] = Color.Green;
                }
                //cyan
                else if (allPixels[i].GetHue() >= 150 && allPixels[i].GetHue() < 180)
                {
                    allPixels[i] = Color.Cyan;
                }
                //lightblue
                else if (allPixels[i].GetHue() >= 180 && allPixels[i].GetHue() < 210)
                {
                    allPixels[i] = Color.LightBlue;
                }
                //turquise
                else if (allPixels[i].GetHue() >= 210 && allPixels[i].GetHue() < 240)
                {
                    allPixels[i] = Color.Turquoise;
                }
                //blue
                else if (allPixels[i].GetHue() >= 240 && allPixels[i].GetHue() < 270)
                {
                    allPixels[i] = Color.Blue;
                }
                //purple    
                else if (allPixels[i].GetHue() >= 270 && allPixels[i].GetHue() < 300)
                {
                    allPixels[i] = Color.Purple;
                }
                //magenta
                else if (allPixels[i].GetHue() >= 300 && allPixels[i].GetHue() < 330)
                {
                    allPixels[i] = Color.Magenta;
                }
                //pink
                else if (allPixels[i].GetHue() >= 330 && allPixels[i].GetHue() < 360)
                {
                    allPixels[i] = Color.Pink;
                }

            }

            //draws image
            for (int y = 0, whichPixel = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++, whichPixel++)
                {
                    picture.SetPixel(x, y, allPixels[whichPixel]);
                }
            }

            pbBild.Image = picture;
        }

        private void InvertColorFilter(object sender, EventArgs e)
        {
            Bitmap picture = GetCurrentImage();
            //creates the array and makes it the size of the amount of pixels
            Color[] allPixels = new Color[picture.Width * picture.Height];

            //gets every pixel
            for (int y = 0, whichPixel = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++, whichPixel++)
                {
                    allPixels[whichPixel] = picture.GetPixel(x, y);
                }
            }

            for (int i = 0; i < allPixels.Length; i++)
            {
                allPixels[i] = Color.FromArgb(255 - allPixels[i].R, 255 - allPixels[i].G, 255 - allPixels[i].B);
            }

            //draws image
            for (int y = 0, whichPixel = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++, whichPixel++)
                {
                    picture.SetPixel(x, y, allPixels[whichPixel]);
                }
            }

            pbBild.Image = picture;
        }

        private void ColorSet(object sender, EventArgs e)
        {

            Bitmap picture = GetCurrentImage();
            //creates the array with the size of all pixels
            Color[] allPixels = new Color[picture.Width * picture.Height];

            //gets every pixel
            for (int y = 0, whichPixel = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++, whichPixel++)
                {
                    allPixels[whichPixel] = picture.GetPixel(x, y);
                }
            }

            //gets what filter it is doing
            ToolStripMenuItem filter = sender as ToolStripMenuItem;

            //which color is swapped to which
            string filterType = filter.Name;


            switch (filterType)
            {
                case "RedToGreen":
                    for (int i = 0; i < allPixels.Length; i++)
                    {
                        if (allPixels[i].R > 0 && allPixels[i].G < 255 && allPixels[i].B < 255)
                        {
                            allPixels[i] = Color.FromArgb(allPixels[i].G, allPixels[i].R, allPixels[i].B);
                        }
                    }
                    break;

                case "RedToBlue":
                    for (int i = 0; i < allPixels.Length; i++)
                    {
                        if (allPixels[i].R > 0 && allPixels[i].G < 255 && allPixels[i].B < 255)
                        {
                            allPixels[i] = Color.FromArgb(allPixels[i].B, allPixels[i].G, allPixels[i].R);
                        }
                    }
                    break;

                case "GreenToRed":
                    for (int i = 0; i < allPixels.Length; i++)
                    {
                        if (allPixels[i].R < 255 && allPixels[i].G > 0 && allPixels[i].B < 255)
                        {
                            allPixels[i] = Color.FromArgb(allPixels[i].G, allPixels[i].R, allPixels[i].B);
                        }
                    }
                    break;

                case "GreenToBlue":
                    for (int i = 0; i < allPixels.Length; i++)
                    {
                        if (allPixels[i].R < 255 && allPixels[i].G > 0 && allPixels[i].B < 255)
                        {
                            allPixels[i] = Color.FromArgb(allPixels[i].R, allPixels[i].B, allPixels[i].G);
                        }
                    }
                    break;

                case "BlueToRed":
                    for (int i = 0; i < allPixels.Length; i++)
                    {
                        if (allPixels[i].R < 255 && allPixels[i].G < 255 && allPixels[i].B > 0)
                        {
                            allPixels[i] = Color.FromArgb(allPixels[i].B, allPixels[i].G, allPixels[i].R);
                        }
                    }
                    break;

                case "BlueToGreen":
                    for (int i = 0; i < allPixels.Length; i++)
                    {
                        if (allPixels[i].R < 255 && allPixels[i].G < 255 && allPixels[i].B > 0)
                        {
                            allPixels[i] = Color.FromArgb(allPixels[i].R, allPixels[i].B, allPixels[i].G);
                        }
                    }
                    break;
            }


            //draws image
            for (int y = 0, whichPixel = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++, whichPixel++)
                {
                    picture.SetPixel(x, y, allPixels[whichPixel]);
                }
            }

            pbBild.Image = picture;
        }

        private void MonochromeColorFilter(object sender, EventArgs e)
        {

            Bitmap picture = GetCurrentImage();
            //creates the array at the size of the amount of pixels
            Color[,] allPixels = new Color[picture.Width, picture.Height];

            //gets every pixel
            for (int y = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++)
                {
                    allPixels[x, y] = picture.GetPixel(x, y);
                }
            }

            for (int y = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++)
                {
                    int shade = (allPixels[x, y].R + allPixels[x, y].G + allPixels[x, y].B) / 3;
                    allPixels[x, y] = Color.FromArgb(shade, shade, shade);
                }
            }

            //draws image
            for (int y = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++)
                {
                    picture.SetPixel(x, y, allPixels[x, y]);
                }
            }

            pbBild.Image = picture;
        }

        private void GrainImageFilter(object sender, EventArgs e)
        {

            Bitmap picture = GetCurrentImage();
            //creates the array with the size of the amount of pixels
            Color[,] allPixels = new Color[picture.Width, picture.Height];
            Random rng = new Random();

            //gets every pixel
            for (int y = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++)
                {
                    allPixels[x, y] = picture.GetPixel(x, y);
                }
            }

            for (int y = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++)
                {
                    int grain = rng.Next(-30, 31);
                    //Math.Min(Math.Max()) clamps the value between acceptable levels

                    allPixels[x, y] = Color.FromArgb(Math.Min(Math.Max(allPixels[x, y].R + grain, 0), 255), Math.Min(Math.Max(allPixels[x, y].G + grain, 0), 255), Math.Min(Math.Max(allPixels[x, y].B + grain, 0), 255));
                }
            }

            //draws image
            for (int y = 0, whichPixel = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++, whichPixel++)
                {
                    picture.SetPixel(x, y, allPixels[x, y]);
                }
            }

            //applies image to the picturebox
            pbBild.Image = picture;
        }

        private void ColorRemove(object sender, EventArgs e)
        {
            Bitmap picture = GetCurrentImage();
            //creates an array with the size of the amount of pixels
            Color[] allPixels = new Color[picture.Width * picture.Height];

            //gets every pixel
            for (int y = 0, whichPixel = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++, whichPixel++)
                {
                    allPixels[whichPixel] = picture.GetPixel(x, y);
                }
            }

            ToolStripMenuItem filter = sender as ToolStripMenuItem;
            switch (filter.Name.ToLower())
            {
                case "removered":
                    //sets all pixels with a R value to 0
                    for (int i = 0; i < allPixels.Length; i++)
                    {
                        if (allPixels[i].R > 0 && allPixels[i] != Color.FromArgb(255, 255, 255))
                        {
                            allPixels[i] = Color.FromArgb(0, allPixels[i].G, allPixels[i].B);
                        }

                    }
                    break;

                case "removegreen":
                    //sets all pixels with a G value to 0
                    for (int i = 0; i < allPixels.Length; i++)
                    {
                        if (allPixels[i].G > 0 && allPixels[i] != Color.FromArgb(255, 255, 255))
                        {
                            allPixels[i] = Color.FromArgb(allPixels[i].R, 0, allPixels[i].B);
                        }
                    }
                    break;

                case "removeblue":
                    //sets all pixels with a R value to 0
                    for (int i = 0; i < allPixels.Length; i++)
                    {
                        if (allPixels[i].B > 0 && allPixels[i] != Color.FromArgb(255, 255, 255))
                        {
                            allPixels[i] = Color.FromArgb(allPixels[i].R, allPixels[i].G, 0);
                        }
                    }
                    break;

                case "removeyellow":
                    //removes all yellow
                    for (int i = 0; i < allPixels.Length; i++)
                    {
                        if (allPixels[i].R == 255 && allPixels[i].G == 255)
                        {
                            allPixels[i] = Color.FromArgb(0, 0, allPixels[i].B);
                        }
                    }
                    break;
            }

            //draws image
            for (int y = 0, whichPixel = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++, whichPixel++)
                {
                    picture.SetPixel(x, y, allPixels[whichPixel]);
                }
            }

            pbBild.Image = picture;
        }

        private void BlurImageFilter(object sender, EventArgs e)
        {
            //Bugs: image shifts to the bottom right corner after every blur

            Bitmap picture = new Bitmap(pbBild.Image);
            Color[,] pixelArray = new Color[picture.Width, picture.Height];

            int blurSize = 4;

            for (int y = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++)
                {

                    pixelArray[x, y] = picture.GetPixel(x, y);

                }
            }

            //every pixel gets copied to a new array so having a set color already is just a failsafe
            //the blur effect calls the colors straight from the pixelArray so it needs to remain unmodified
            Color[,] copyArray = pixelArray;

            //gaussian blur equation stuff
            //double o = 0.683;
            //double formula = 1 / (2 * Math.PI * Math.Pow(0, 2));

            //selecting the pixel
            for (int y = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++)
                {
                    //applying blur to every pixel
                    int RSum = 0;
                    int GSum = 0;
                    int BSum = 0;
                    int pixels = 0;

                    //math.max stops negative positions which cause index out of array errors 
                    for (int yOffset = Math.Max(y - blurSize, 0); yOffset < y + blurSize; yOffset++)
                    {
                        for (int xOffset = Math.Max(x - blurSize, 0); xOffset < x + blurSize; xOffset++)
                        {
                            //gaussian blur equation stuff
                            //double eRaise = ((xOffset ^ 2) * (yOffset ^ 2)) / 2 * (Math.Pow(o, 2));
                            //double blur = formula * Math.Pow(Math.E, -1 * eRaise);

                            //math min stops faulty coordinates
                            if (xOffset < picture.Width && yOffset < picture.Height)
                            {
                                RSum += pixelArray[xOffset, yOffset].R;
                                GSum += pixelArray[xOffset, yOffset].G;
                                BSum += pixelArray[xOffset, yOffset].B;
                                pixels++;
                            }



                        }
                    }

                    //gets the new rgb value for the pixel
                    RSum /= pixels;
                    GSum /= pixels;
                    BSum /= pixels;

                    copyArray[x, y] = Color.FromArgb(RSum, GSum, BSum);

                }
            }


            //paint picture
            for (int y = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++)
                {
                    picture.SetPixel(x, y, copyArray[x, y]);
                }
            }

            copyArray = null;

            pbBild.Image = picture;

        }

        private void MergeImage(object sender, EventArgs e)
        {
            if (openImage.ShowDialog() == DialogResult.OK)
            {
                Bitmap picture1 = GetCurrentImage();
                Bitmap picture2 = new Bitmap(openImage.FileName);

                //how do i merge larger images; i need to downsize or enlarge it that means i need to fix the scale function first
            }
        }

        private void ChangeBrightness(object sender, EventArgs e)
        {

            //detta är lossy om man maxar rgb värdet vilket betyder att om man vill ha lossless så måste man sätta filter på lager, alltså man har en queue med filter som utförs på rad

            BrightSlide.ShowDialog();

            Bitmap picture = GetCurrentImage();
            Color[,] pixelArray = new Color[picture.Width, picture.Height];

            if (BrightSlide.DialogResult == DialogResult.OK)
            {
                //make brighter
                int howBright = BrightSlide.Value;

                

                //increases brightness/increases rgb sum
                for (int y = 0; y < picture.Height; y++)
                {
                    for (int x = 0; x < picture.Width; x++)
                    {

                        pixelArray[x, y] = Color.FromArgb(RGBClamp(pixelArray[x, y].R + howBright), RGBClamp(pixelArray[x, y].G + howBright), RGBClamp(pixelArray[x, y].B + howBright));

                    }
                }


                for (int y = 0; y < picture.Height; y++)
                {
                    for (int x = 0; x < picture.Width; x++)
                    {
                        picture.SetPixel(x, y, pixelArray[x, y]);
                    }
                }

                pbBild.Image = picture;

            }



        }

        private void Scale(object sender, EventArgs e)
        {

            ToolStripMenuItem button = sender as ToolStripMenuItem;


            Image pic = pbBild.Image;
            Bitmap newImage = new Bitmap(pic.GetThumbnailImage(pic.Width / 2, pic.Height/2, null, IntPtr.Zero));

            pbBild.Image = newImage;
            

        }
        private void ResizeImage(object sender, EventArgs e)
        {
            if (pbBild.Image != null)
            {
                Image newSize = pbBild.Image;

                pbBild.Image = newSize.GetThumbnailImage(mainForm.ActiveForm.Size.Width, mainForm.ActiveForm.Size.Height, null, IntPtr.Zero);

                pbBild.Width = newSize.Width;
                pbBild.Height = newSize.Height;
            }
            

        }

        #endregion

        #region Drawing tools

        //Paint brush pseudo code
        //when mouse is down on the image then set the pixel, if it isn't already, to the brush color and don't update it if it isn't on a different pixel
        // keep coloring to the current displayed image but reference the old one until the mouse button is let go


        //to learn:
        //select specific pixels depending on a shape like a circle and not a square

        private void DrawSelectColor(object sender, EventArgs e)
        {
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {

                brushColor = colorPicker.Color;

                //sets the image to the selected color
                ToolStripMenuItem button = sender as ToolStripMenuItem;
                Bitmap logo = new Bitmap(16, 16);

                for (int y = 0; y < logo.Height; y++)
                {
                    for (int x = 0; x < logo.Width; x++)
                    {
                        logo.SetPixel(x, y, brushColor);
                    }
                }

                button.Image = logo;

            }
        }

        private void StartPaint(object sender, MouseEventArgs e)
        {
            painting = true;
        }

        private void StopPaint(object sender, MouseEventArgs e)
        {
            painting = false;
            GetCurrentImage();

        }

        private async Task<Bitmap> DrawPaintAsync(MouseEventArgs e)
        {

            int brushSize = 10;
            Bitmap image = new Bitmap(pbBild.Image);

            for (int y = 0; y < brushSize; y++)
            {
                for (int x = 0; x < brushSize; x++)
                {
                    image.SetPixel(Clamp(0, e.X - brushSize / 2 + x, image.Width - 1), Clamp(0, e.Y - brushSize / 2 + y, image.Height - 1), brushColor);
                }
            }

            return image;
        }

        private async void TrackMouse(object sender, MouseEventArgs e)
        {
            if (pbBild.Image != null)
            {
                if (painting)
                {
                    //when mouse moves it calls the async drawpaint method
                    Task<Bitmap> paintImage = DrawPaintAsync(e);

                    Bitmap image = await paintImage;

                    pbBild.Image = image;
                }
            }
        }

        #endregion

        
    }
}
