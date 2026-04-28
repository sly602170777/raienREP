using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph366
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
            // 普通の直線
            g.DrawLine(Pens.Black, 0, 0, pictureBox1.Width, 0);
            // 太い線
            var bold = new Pen(Color.Black, 5);
            g.DrawLine(bold, 0, 50, pictureBox1.Width, 50);
            // 点線
            var dot = new Pen(Color.Black)
            {
                DashStyle = System.Drawing.Drawing2D.DashStyle.Dot
            };
            g.DrawLine(dot, 0, 100, pictureBox1.Width, 100);
        }
    }
}
