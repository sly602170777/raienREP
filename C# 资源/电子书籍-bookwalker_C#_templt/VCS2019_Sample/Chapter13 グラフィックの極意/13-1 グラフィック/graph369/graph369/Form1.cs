using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph369
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
            var points = new Point[4];
            // 多角形を描画する
            points[0] = new Point(50, 0);
            points[1] = new Point(100, 50);
            points[2] = new Point(50, 100);
            points[3] = new Point(0, 50);
            g.DrawLines(Pens.Black, points);
            // 閉じた多角形を描画する
            points[0] = new Point(100, 0);
            points[1] = new Point(150, 50);
            points[2] = new Point(100, 100);
            points[3] = new Point(50, 50);
            g.DrawPolygon(Pens.Red, points);
        }
    }
}
