using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph377
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
            var img1 = Properties.Resources.kaho;
            var img2 = Properties.Resources.frame;
            // 透明色を設定する
            var ia = new System.Drawing.Imaging.ImageAttributes();
            ia.SetColorKey(Color.Red, Color.Red);
            // 背景の画像を描画する
            g.DrawImage(img1, new Rectangle(new Point(0, 0), img1.Size));
            // 重ね合わせの画像を描画する
            g.DrawImage(img2, new Rectangle(new Point(0, 0), img2.Size), 0, 0, img2.Width, img2.Height, GraphicsUnit.Pixel, ia);
        }
    }
}
