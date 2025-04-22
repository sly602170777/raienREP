using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file270
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
            if (path == string.Empty)
            {
                return;
            }
            var fs = new System.IO.StreamWriter(path);
            fs.WriteLine(DateTime.Now.ToString());  // 日付
            fs.Write(textBox2.Text);                // 出力データ
            fs.WriteLine("");                       // 改行
            fs.Close();
            MessageBox.Show("ファイルに出力しました");
        }
    }
}
