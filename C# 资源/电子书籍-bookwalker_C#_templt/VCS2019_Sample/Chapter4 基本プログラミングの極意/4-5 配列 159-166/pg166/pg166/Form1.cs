using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg166
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int[] ary1 = { 10, 20, 30 };
            // CopyTo で配列をコピー
            int[] ary2 = new int[ary1.Length];
            ary1.CopyTo(ary2, 0);
            // Clone で配列をコピー
            int[] ary3 = (int[])ary1.Clone();
            // オブジェクトの参照のみ
            int[] ary4 = ary1;

            // 元の配列 ary1 を変更する
            ary1[0] = 99;

            label1.Text = "ary1 = ";
            label2.Text = "ary2 = ";
            label3.Text = "ary3 = ";
            label4.Text = "ary4 = ";
            foreach ( var it in ary1 )
            {
                label1.Text += $"{it}, ";
            }
            foreach (var it in ary2)
            {
                label2.Text += $"{it}, ";
            }
            foreach (var it in ary3)
            {
                label3.Text += $"{it}, ";
            }
            foreach (var it in ary4)
            {
                label4.Text += $"{it}, ";
            }
        }
    }
}
