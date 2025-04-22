using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui104
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(300, 300);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Width = 100;
            pictureBox1.Height = 100;
        }
    }
}
