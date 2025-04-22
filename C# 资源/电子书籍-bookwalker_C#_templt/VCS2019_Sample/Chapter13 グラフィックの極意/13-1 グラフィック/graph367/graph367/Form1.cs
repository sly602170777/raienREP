using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph367
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
            // 四角形を描画する
            g.DrawRectangle(Pens.Black, 0, 0, 100, 100);
            // 塗り潰した四角形を描画する
            g.FillRectangle(Brushes.Red, 50, 50, 100, 100);
        }
    }
}
