using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file263
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            if ( path == string.Empty )
            {
                return;
            }
            if ( System.IO.File.Exists( path ) == false )
            {
                MessageBox.Show("ファイルが見つかりません");
                return;
            }
            var fs = System.IO.File.OpenRead(path);
            MessageBox.Show("読み取り専用でファイルを開きました");
            fs.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            if (path == string.Empty)
            {
                return;
            }
            if (System.IO.File.Exists(path) == false)
            {
                MessageBox.Show("ファイルが見つかりません");
                return;
            }
            var fs = System.IO.File.OpenWrite(path);
            MessageBox.Show("書き込み用にファイルを開きました");
            fs.Close();
        }
    }
}
