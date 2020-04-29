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
            TextBox box = sender as TextBox;

            if (box.Text == "")
                return;

            char[] alphabet = "abcdefghijklmnopqrstuvwxyzåäö".ToCharArray();
            
            //every input it removes letters

            box.Select(box.Text.Length, 0);

            if (proportionate)
            {
                //code to keep numbers proportionate
                //fixa att den håller ration och inte bara kopierar vad det står
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
    }
}
