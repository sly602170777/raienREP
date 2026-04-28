using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg186
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 初期のラムダ式を設定しておく
        Func<int, int, int> _func = (x, y) => 0;
        // ラムダ式を設定する
        private void Button1_Click(object sender, EventArgs e)
        {
            if ( radioButton1.Checked )
            {
                _func = (x, y) => x + y;
            }
            if (radioButton2.Checked)
            {
                _func = (x, y) => x * y;
            }
            if (radioButton3.Checked)
            {
                _func = (x, y) => (int)Math.Pow((double)x ,(double)y );
            }
        }
        // ラムダ式を実行
        private void Button2_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text);
            int b = int.Parse(textBox2.Text);
            int ans = _func(a, b);
            label1.Text = ans.ToString();
        }
    }
}
