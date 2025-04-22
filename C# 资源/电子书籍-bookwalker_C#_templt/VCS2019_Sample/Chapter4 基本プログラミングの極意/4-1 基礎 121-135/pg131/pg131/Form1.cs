using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg131
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string ss="Hello";
            // パスを示す
            label3.Text = @"C:\C#2019\Sample.txt";
            // JSON形式
            label4.Text = @"{ name: ""masuda"", country: ""Japan"" ,Word:ss}";
            // 改行を含む文字列
            label5.Text = @"
このように改行を含めた
文章を書くことができる。
ヒアドキュメントを書くときに使う。
";

        }
    }
}
