using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui048
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Opacity += 0.02;
            label1.Text = "不透明度：" + Opacity.ToString();           
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (Opacity >= 0.3)
            {
                Opacity -= 0.02;
                label1.Text = "不透明度：" + Opacity.ToString();
            }
            else
            {
                MessageBox.Show("これ以上透明にできません");
            }            
        }
    }
}
