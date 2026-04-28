using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui077
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (TabPage myTP in tabControl1.TabPages)
            {
                foreach (RadioButton myRB in myTP.Controls)
                {
                    if (myRB.Checked)
                    {
                        listBox1.Items.Add(myRB.Text);
                    }
                }
            }

        }
    }
}
    

