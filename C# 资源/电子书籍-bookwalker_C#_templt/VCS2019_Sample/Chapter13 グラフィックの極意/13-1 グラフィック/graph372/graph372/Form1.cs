using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph372
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
            // セピア色に変換する
            var cm = new System.Drawing.Imaging.ColorMatrix();
            cm.Matrix00 = 0.393f;
            cm.Matrix01 = 0.349f;
            cm.Matrix02 = 0.272f;
            cm.Matrix10 = 0.769f;
            cm.Matrix11 = 0.686f;
            cm.Matrix12 = 0.534f;
            cm.Matrix20 = 0.189f;
            cm.Matrix21 = 0.168f;
            cm.Matrix22 = 0.131f;
            cm.Matrix33 = 1f;
            cm.Matrix44 = 1f;
            var ia = new System.Drawing.Imaging.ImageAttributes();
            ia.SetColorMatrix(cm);
            // 画像を描画する
            var img = Properties.Resources.kaho;
            var rect = new Rectangle(0, 0, img.Width, img.Height);
            g.DrawImage(img, rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
        }
    }
}
