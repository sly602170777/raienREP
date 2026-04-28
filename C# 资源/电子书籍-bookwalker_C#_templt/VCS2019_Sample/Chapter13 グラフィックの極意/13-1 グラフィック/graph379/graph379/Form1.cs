using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph379
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
            var img = Properties.Resources.book;
            g.DrawImage(img, new Point(0, 0));
            // 画像に文字を入れる
            g.DrawString(DateTime.Now.ToString("yyyy-MM-dd"),
                new Font("Meiryo", 30.0f),
                new SolidBrush(Color.Red),
                new Point(0, 0));
        }
    }
}
