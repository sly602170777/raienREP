using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg182
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string checkTest( bool result, params string[] kamoku )
        {
            if ( result == true )
            {
                return "合格";
            }
            else
            {
                var gouhi = "追加試験 -> ";
                foreach ( var it in kamoku )
                {
                    gouhi += it + ", ";
                }
                return gouhi;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // 最初の引数のみ指定
            label1.Text = checkTest(true);
            // ２番目の引数を１つ指定
            label2.Text = checkTest(false, "国語");
            // ２番目の引数を３つ指定
            label3.Text = checkTest(false, "国語","数学","英語");
        }
    }
}
