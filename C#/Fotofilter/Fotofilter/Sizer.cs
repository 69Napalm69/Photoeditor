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
        public Sizer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newWidth = int.Parse(tbxWidth.Text);
            newHeight = int.Parse(tbxHeight.Text);
            Close();
        }

        private void FilterText(object sender, EventArgs e)
        {
            //gets the textbox
            TextBox box = sender as TextBox;

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
        }

        private void OnLoad(object sender, EventArgs e)
        {
            tbxWidth.Text = mainForm.currentWidth.ToString();
            tbxHeight.Text = mainForm.currentHeight.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //closes form
            Close();
        }
    }
}
