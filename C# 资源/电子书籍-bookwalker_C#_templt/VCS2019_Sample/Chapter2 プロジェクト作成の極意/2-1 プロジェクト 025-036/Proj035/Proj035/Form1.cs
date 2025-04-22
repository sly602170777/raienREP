using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj035
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //追加したリソースの文字列をラベルに表示
            label1.Text = Properties.Resources.String1;
            //追加したリソースファイルをピクチャーボックスに表示
            pictureBox1.Image = Properties.Resources.sweet01;
            //画像の大きさを縦横の比率を変更せずに枠に合わせる
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
