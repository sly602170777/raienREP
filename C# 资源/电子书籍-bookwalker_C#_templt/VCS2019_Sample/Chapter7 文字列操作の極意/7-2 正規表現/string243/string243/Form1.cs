using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace string243
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
            var rx = new Regex(".+[都道府県]");
            if ( rx.IsMatch( text ) )
            {
                textBox2.Text = $"県名は {text} です";
            }
            else
            {
                textBox2.Text = "都道府県名を入力してください";
            }
        }
    }
}
