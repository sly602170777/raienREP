using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg161
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int[] xAry = new int[5];
            int[,] yAry = new int[2, 3];

            label1.Text = $"xAry[5]の要素数：{xAry.Length}";
            label2.Text =
                $"yAry[2, 3]の全要素数：{yAry.Length}\n"
                + $"1つ目の次元の要素数：{yAry.GetLength(0)}\n"
                + $"2つ目の次元の要素数：{yAry.GetLength(1)}\n" 
                + $"...つ目の次元の要素数：{xAry.Length}\n"
                + $"Up..つ目の次元の要素数：{xAry.GetUpperBound(0)}\n"
                + $"Rank..つ目の次元の要素数：{yAry.GetUpperBound(1)}"
            ;
        }
    }
}
