using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg184
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            button1.Click += (s, e) =>
            {
                label1.Text = "ラムダ式で実行しました";
            };
            
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            label1.Text = "イベントで実行しました";
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
