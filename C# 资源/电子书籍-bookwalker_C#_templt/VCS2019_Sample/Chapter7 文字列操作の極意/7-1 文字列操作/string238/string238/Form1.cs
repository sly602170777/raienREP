using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace string238
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            if ( text.Length < 4 )
            {
                MessageBox.Show("4文字以上入力してください");
                return;
            }
            //从下标1开始取三位数
            textBox2.Text = text.Remove(1, 3);
        }
    }
}
