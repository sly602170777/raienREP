using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace string242
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var lst = new List<string>();
            foreach ( var it in listBox1.Items)
            {
                lst.Add(it.ToString());
            }
            textBox1.Text = "-----"+ string.Join("|", lst);
        }
    }
}
