using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file268
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
            var fs = System.IO.File.CreateText(path);
            fs.Close();
            MessageBox.Show("ファイルを作成しました");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            if (path == string.Empty)
            {
                return;
            }
            var fs = new System.IO.StreamWriter(path, false,
                System.Text.Encoding.GetEncoding("shift_jis"));
            fs.Close();
            MessageBox.Show("ファイルを作成しました");
        }
    }
}
