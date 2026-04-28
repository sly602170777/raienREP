using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui038
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            label1.Text = "Fixed3D";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            label1.Text = "FixedDialog";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            label1.Text = "FixedSingle";
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            label1.Text = "FixedToolWindow";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            label1.Text = "Sizable";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            label1.Text = "SizableToolWindow";
        }
    }
}
