using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fotofilter
{
    public partial class Sizer : Form
    {
        public static int newWidth;
        public static int newHeight;
        private double proportion;
        private bool proportionate = false;
        public Sizer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //save button
            newWidth = int.Parse(tbxWidth.Text);
            newHeight = int.Parse(tbxHeight.Text);
            Close();
        }

        private void FilterText(object sender, EventArgs e)
        {

            //gets the textbox
            TextBox box = sender as TextBox;

            if (box.Text == "")
                return;

            //gets the current text
            string temp = box.Text.ToLower();

            //char array with all letters for the string.split method
            char[] alphabet = "abcdefghijklmnopqrstuvwxyzåäö".ToCharArray();

            //this is done like this in the case of a paste with several letters in it
            string[] tempSplit = temp.Split(alphabet, StringSplitOptions.RemoveEmptyEntries);

            //makes string empty to reuse it
            temp = null;
            for (int i = 0; i < tempSplit.Length; i++)
            {
                //removes the first character which will be a letter because of split splitting on it
                tempSplit[i].Remove(0);
                temp += tempSplit[i];
            }

            //sets the box to have the new text and puts the selection cursor thingie at the end of said box as to make the filter seamless
            box.Text = temp;
            box.Select(box.Text.Length, 0);


            if (proportionate)
            {
                //code to keep numbers proportionate
                //problem: den triggrar "text changed" sigsjälv BYT TILL KEY DOWN
                switch (box.Name)
                {
                    case "tbxWidth":
                        tbxHeight.Text = Convert.ToString(Convert.ToInt32(Convert.ToDouble(tbxWidth.Text) * proportion));
                        return;

                    case "tbxHeight":
                        tbxWidth.Text = Convert.ToString(Convert.ToInt32(Convert.ToDouble(tbxHeight.Text) / proportion));
                        return;

                }

            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            tbxWidth.Text = mainForm.currentWidth.ToString();
            tbxHeight.Text = mainForm.currentHeight.ToString();
            proportion = mainForm.currentWidth / mainForm.currentHeight;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //exit button
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            proportionate = checkBox1.Checked;
        }

        private void FilterInput(object sender, KeyEventArgs e)
        {
            
        }
    }
}
