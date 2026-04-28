using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui065
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;  //ラジオボタン１をオンにする
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string myString = "";
            
            if(radioButton1.Checked)
            {
                myString = radioButton1.Text;
            }
            else if(radioButton2.Checked)
            {
                myString = radioButton2.Text;
            }
            else if (radioButton3.Checked)
            {
                myString = radioButton3.Text;
            }

            label1.Text = myString;
        }
    }
}
