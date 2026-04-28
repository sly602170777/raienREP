using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace string231
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
            textBox2.Text = "";
            if ( text.Length < 7 )
            {
                MessageBox.Show("7文字以上入力してください");
                return;
            }
            // 3文字分取得する
            textBox2.Text = text.Substring(4, 3);
        }
    }
}
