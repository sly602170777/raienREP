using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg158
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string s1 = "";
            string s2 = "";
            /// チェックボックスを調べる
            foreach( CheckBox chk in groupBox1.Controls )
            {
                if ( chk.Checked )
                {
                    s1 += chk.Text + "---";
                    continue;
                }
                // 残りの項目
                s2 += chk.Text + "*****";
            }
            label1.Text = $"{s1} を選択しました";
            label2.Text = $"{s2} が未選択でした";
        }
    }
}
