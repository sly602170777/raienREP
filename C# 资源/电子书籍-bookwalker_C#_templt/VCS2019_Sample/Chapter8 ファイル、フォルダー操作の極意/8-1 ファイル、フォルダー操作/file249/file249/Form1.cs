using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file249
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string fname1 = textBox1.Text;
            string fname2 = textBox2.Text;
            // 移動元フォルダーが存在し、移動先フォルダーが存在しなければ移動
            if ( System.IO.Directory.Exists( fname1 ) == true &&
                 System.IO.Directory.Exists( fname2 ) == false )
            {
                System.IO.Directory.Move(fname1, fname2);
                textBox3.Text = "移動しました。";
            }
            else
            {
                textBox3.Text = "移動できませんでした。";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string fname1 = textBox1.Text;
            string fname2 = textBox2.Text;
            // 移動元ファイルが存在し、移動先ファイルが存在しなければ移動
            if (System.IO.File.Exists(fname1) == true &&
                 System.IO.File.Exists(fname2) == false)
            {
                System.IO.File.Move(fname1, fname2);
                textBox3.Text = "移動しました。";
            }
            else
            {
                textBox3.Text = "移動できませんでした。";
            }
        }
    }
}
