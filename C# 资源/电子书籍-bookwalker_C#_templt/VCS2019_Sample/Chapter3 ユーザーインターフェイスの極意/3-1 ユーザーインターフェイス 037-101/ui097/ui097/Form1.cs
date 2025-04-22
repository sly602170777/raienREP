using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui097
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(textBox1.Text) == false)
            {
                MessageBox.Show("フォルダーが存在しません", "通知");
                return;
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("ファイル名を指定してください", "通知");
                return;
            }
            richTextBox1.SaveFile(textBox1.Text + @"\" + textBox2.Text + ".txt",
                RichTextBoxStreamType.PlainText);
                MessageBox.Show("ファイルを保存しました", "通知");
        }
    }
}
