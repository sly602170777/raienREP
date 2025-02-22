using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph381
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog()
            {
                Title = "画像を選択",
                Filter = "画像ファイル(*.jpg)|*.jpg|画像ファイル(*.png)|*.png"
            };
            if ( dlg.ShowDialog() != DialogResult.OK )
            {
                return;
            }
            string path = dlg.FileName;
            var img = Image.FromFile(path);
            if ( img == null )
            {
                MessageBox.Show("ファイルが開けませんでした");
                return;
            }
            pictureBox1.Image = img;
        }
    }
}
