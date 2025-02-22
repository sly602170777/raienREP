using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kiso010
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //オブジェクト「textBox2」にオブジェクト「textBox1」の
            //文字列と改行記号を追加する（引数のあるメソッド）
            textBox2.AppendText(textBox1.Text + Environment.NewLine);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //オブジェクト「textBox2」の文字列を消去する
            //（引数のないメソッド）
            textBox2.Clear();
        }
    }
}
