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

namespace string246
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


            var rx = new Regex("/\\w+[都道府県]");
            var coll = rx.Matches(text);
            listBox1.Items.Clear();
            foreach ( var it in coll )
            {
                listBox1.Items.Add(it);
            }
        }
    }
}
