using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg183
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 数値を加算する
        int add( int x, int y )
        {
            return x + y;
        }
        // 文字列を結合する
        string add( string x, string y )
        {
            return x + " " + y;
        }
        // 指定した数だけ文字列を結合する
        string add( string x, int n )
        {
            var result = "";
            for( int i=0; i<n; i++ )
            {
                result += x + " ";
            }
            return result;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            label1.Text = add(10, 20).ToString();
            label2.Text = add("masuda", "tomoaki");
            label3.Text = add("ABC", 5);
        }
    }
}
