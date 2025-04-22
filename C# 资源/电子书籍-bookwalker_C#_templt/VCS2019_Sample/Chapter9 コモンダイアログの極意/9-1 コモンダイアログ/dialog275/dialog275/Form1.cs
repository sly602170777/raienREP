using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dialog275
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog()
            {
                Title = "保存する画像ファイルの選択",
                Filter = "画像ファイル(*.jpg)|*.jpg|画像ファイル(*.png)|*.png"
            };
            if (dlg.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            textBox1.Text = System.IO.Path.GetFileName( dlg.FileName);
            if ( dlg.FilterIndex == 1 )
            {
                pictureBox1.Image.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else
            {
                pictureBox1.Image.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
            textBox2.Text = "保存しました";
        }
    }
}
