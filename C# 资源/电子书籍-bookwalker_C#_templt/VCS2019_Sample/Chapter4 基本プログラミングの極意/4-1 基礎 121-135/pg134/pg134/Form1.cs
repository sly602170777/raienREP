using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg134
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int? x;
            Nullable<int> b;  //🔺同上
            if ( textBox1.Text == "" )
            {
                b = null;
            }
            else
            {
                b = int.Parse(textBox1.Text);
                // x = (int32)textBox1.Text;
            }

            if (b is null )
            {
                label1.Text = "値がありません";
                label2.Text = "";
            } else
            {
                label1.Text = "値があります";
                label2.Text = b.ToString();
            }
        }
    }
}
