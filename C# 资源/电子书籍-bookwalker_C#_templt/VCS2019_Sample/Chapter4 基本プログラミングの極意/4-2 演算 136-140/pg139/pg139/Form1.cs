using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg139
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            foreach (Control obj in this.Controls)
            {
                if (obj is Button)            //Buttonと等しい場合
                {
                    obj.Text = "Clicked!";      //プロパティの値を変更
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control checkBox2 in Controls)
            {
                if (checkBox2 is Button)            //Buttonと等しい場合
                {
                    checkBox2.Text = "checkBox2 is Clicked!";      //プロパティの値を変更
                }
            }
        }
    }
}
