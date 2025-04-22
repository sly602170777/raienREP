using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph378
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var g = pictureBox1.CreateGraphics();
            // 画像の大きさを変える
            var img = Properties.Resources.book;
            var mx = new System.Drawing.Drawing2D.Matrix();
            mx.Scale(2.0f, 2.0f);
            g.Transform = mx;
            g.DrawImage(img, new Point(0, 0));
        }
    }
}
