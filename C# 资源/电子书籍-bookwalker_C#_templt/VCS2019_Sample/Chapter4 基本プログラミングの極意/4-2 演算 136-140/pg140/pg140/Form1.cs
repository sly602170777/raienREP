using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg140
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int? x;  //X这里有可能是null
            string txt = textBox1.Text;
            int b ;
            //判段 txt 传入的值 是否为数字类型
            if (txt == "" && int.TryParse(txt,out b))
            {
                x = null;
                label2.Text = "変数 x = Null";
            }
            else if (int.TryParse(txt, out b))
            {
                x = int.Parse(txt);
                label2.Text = "変数 x = " + DateTime.Now.Day;
            }
            else
            {
                MessageBox.Show("dame");
            }

            #region 用正则判断是否是数字
            //bool IsNumeric(string _string)
            //{
            //    int x=10;
            //    int.TryParse(_string, out x);
            //     return Regex.IsMatch(_string, @"^[+-]?/d*[.]?/d*$");
            //}
            #endregion


        }

    }
}
