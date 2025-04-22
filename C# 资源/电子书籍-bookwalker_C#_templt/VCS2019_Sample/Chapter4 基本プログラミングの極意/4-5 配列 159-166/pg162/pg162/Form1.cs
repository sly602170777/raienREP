using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg162
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var ary = new string[] { "東京", "名古屋", "大阪" };
            string s1 = $"変更前の要素数 : {ary.Length} \n";
            foreach ( var it in ary )
            {
                s1 += it+" ";
            }
            label1.Text = s1;

            var lst = ary.ToList();
            lst.Add("広島");
            lst.Add("福岡");
            ary = lst.ToArray();

            string s2 = $"変更後の要素数 : {ary.Length} \n";
            foreach (var it in ary)
            {
                s2 += $"{it} ";
            }
            label2.Text = s2;
        }
    }
}
