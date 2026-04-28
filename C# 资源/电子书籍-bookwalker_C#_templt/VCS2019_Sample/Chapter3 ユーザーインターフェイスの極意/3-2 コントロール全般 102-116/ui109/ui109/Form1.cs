using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui109
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            RadioButton rd;
            if (radioButton1.Checked)
            {
                rd = radioButton1;
            }
            else
            {
                rd = radioButton2;
            }

            MessageBox.Show("氏名：" +textBox1.Text+ "\n" +
                "性別：" + rd.Text + "\n" + 
                "コメント：" +　richTextBox1.Text, "結果" );
        }
    }
}
