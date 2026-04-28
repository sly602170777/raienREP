using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui105
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Left = 10;
            pictureBox1.Top = 50;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int myLeft = pictureBox1.Left;
            int myTop = pictureBox1.Top;
            if (myTop<=200)
            {
                pictureBox1.Location = new Point(myLeft + 5, myTop + 5);
            }
        }
    }
}
