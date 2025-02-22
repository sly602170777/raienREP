using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file269
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
            var fs = System.IO.File.AppendText(path);
            fs.WriteLine(textBox2.Text);
            fs.Close();
            MessageBox.Show("ファイルに追加しました");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            if (path == string.Empty)
            {
                return;
            }
            var fs = new System.IO.StreamWriter(path, true,
                System.Text.Encoding.GetEncoding("shift_jis"));
            fs.WriteLine(textBox2.Text);
            fs.Close();
            MessageBox.Show("ファイルに追加しました");
        }
    }
}
