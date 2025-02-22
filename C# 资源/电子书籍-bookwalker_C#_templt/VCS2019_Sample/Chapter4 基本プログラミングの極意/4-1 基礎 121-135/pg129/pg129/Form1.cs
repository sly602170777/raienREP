using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg129
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            double answer = 0.0;      //数値型で宣言

            //テキストボックスの文字列をdouble型に変換して計算する
            answer = double.Parse(textBox1.Text)
                   + Convert.ToDouble(textBox2.Text);

            //double型の数値を文字列に変換して表示する
            this.textBox3.Text = answer.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime dNow = System.DateTime.Now;
             string str = label3.Text;
            str = (System.DateTime.Now).ToString();
            // string TB4 = textBox4.Text;   不能设置为变量 会改变储存地址
            int number =22;
            bool ret = DateTime.TryParse(str, out dNow);
            if (int.TryParse(str, out number))
            {
                textBox4.Text = number.ToString(); 
            }
            else if (ret)
            {
                textBox4.Text = dNow.ToString();
            }
            else
            {
                textBox4.Text = "输入正确的日期。。。";
            }
        }
    }
}
