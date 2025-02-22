using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui096
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(textBox1.Text) == false)
            {
                MessageBox.Show("ファイルが存在しません", "通知");
                return;
            }
            if (textBox1.Text.EndsWith("txt"))
            {
                richTextBox1.LoadFile(textBox1.Text,
                    RichTextBoxStreamType.PlainText);
            }
            else if (textBox1.Text.EndsWith("rtf"))
            {
                richTextBox1.LoadFile(textBox1.Text,
                    RichTextBoxStreamType.RichText);
            }
            else
            {
                MessageBox.Show("txt、rtf形式のファイルを指定してください", "通知");
            }
        }
    }
}
