using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph368
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
            // 円を描画する
            g.DrawEllipse(Pens.Black, 0, 0, 100, 100);
            // 塗り潰した円を描画する
            g.FillEllipse(Brushes.Red, 50, 50, 100, 100);
            // 作成したBrashオブジェクトを指定
            var br = new TextureBrush(Properties.Resources.book);
            g.FillEllipse(br, 100, 100, 100, 100);
        }
    }
}
