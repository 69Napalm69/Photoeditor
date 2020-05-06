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
            //save button
            newWidth = int.Parse(tbxWidth.Text);
            newHeight = int.Parse(tbxHeight.Text);
            Close();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            tbxWidth.Text = mainForm.currentWidth.ToString();
            tbxHeight.Text = mainForm.currentHeight.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //exit button
            Close();
        }
    }
}
