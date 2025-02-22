using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace string241
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            // 文字を指定して分割  单个字符分割
            var ary = text.Split('/');
            listBox1.Items.Clear();
            foreach ( var t in ary )
            {
                listBox1.Items.Add(t);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            if (text=="")
            {
                listBox1.Items.Add("is NULL");
            }
            // 文字列を指定して分割  可以指定多个分割字符  new string[]{}
            var ary = text.Split(new string[] { "@", "?" },
                StringSplitOptions.None);
            listBox1.Items.Clear();
            //遍历文字列
            foreach (var t in ary)
            {
                listBox1.Items.Add(t);
            }
        }
    }
}
