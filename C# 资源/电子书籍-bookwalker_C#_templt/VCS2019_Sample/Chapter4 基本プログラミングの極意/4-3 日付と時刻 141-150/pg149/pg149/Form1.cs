using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg149
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DateTime dt;
            bool ret = DateTime.TryParse(textBox1.Text, out dt);
            if (ret)
            {
                label1.Text = dt.ToString();
            }
            else
            {
                label1.Text = "DateTime型の値に変換できません。";
            }
        }
    }
}
