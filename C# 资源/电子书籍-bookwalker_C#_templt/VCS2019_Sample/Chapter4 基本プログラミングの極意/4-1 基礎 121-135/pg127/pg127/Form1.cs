using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg127
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Rank 列挙型を定義する
        enum Rank       //データ型を省略しているのでint型となる
        {
            Special=2,    //0
            Standard,   //1
            Basic,      //2
        }

        private Rank checkRank( int num)
        {
            if ( num >= 80 )
            {
                return Rank.Special;
            }
            else if ( num >= 60 )
            {
                return Rank.Standard;
            }
            else
            {
                return Rank.Basic;
            }
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            int num = int.Parse(textBox1.Text);

            Rank result = checkRank(num);
            label1.Text = result.ToString();
            label2.Text = ((int)result).ToString();
        }
    }
}
