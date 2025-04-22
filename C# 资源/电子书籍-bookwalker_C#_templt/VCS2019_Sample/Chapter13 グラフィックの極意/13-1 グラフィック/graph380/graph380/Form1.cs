using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph380
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var img = new Bitmap(Properties.Resources.book);
            var g = Graphics.FromImage(img);
            var mx = new System.Drawing.Drawing2D.Matrix();
            g.DrawImage(img, new Point(0, 0));
            g.DrawString(DateTime.Now.ToString("HH:mm"),
                new Font("Meiryo", 30.0f),
                new SolidBrush(Color.Red),
                new Point(0, 0));
            this.pictureBox1.Image = img;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var img = pictureBox1.Image;
            img.Save(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".png",
                System.Drawing.Imaging.ImageFormat.Png);
            MessageBox.Show("画像を保存しました");
        }
    }
}
