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

namespace dialog274
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
                Title = "画像ファイルの選択",
                CheckFileExists = true,
                RestoreDirectory = true,
                Filter = "イメージファイル|*.bmp;*.jpg;*.gif;*.png"
            };
            if ( dlg.ShowDialog() == DialogResult.OK )
            {
                textBox1.Text = dlg.FileName;
                textBox2.Text = dlg.SafeFileName;
                pictureBox1.Image = Image.FromFile(dlg.FileName);
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                pictureBox1.Image = null;
            }
        }
    }
}
