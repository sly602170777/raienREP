using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace string233
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
            //int pos =-1;

            //listBox1.Items.Clear();
            //while (true)
            //{
            //    pos = text.IndexOf("セ", pos+1 );
            //    if (pos == -1)
            //    {
            //        break;
            //    }
            //    listBox1.Items.Add(pos + 1 + "文字目");
            //}

            int index = -1;
            listBox1.Items.Clear();
            while (true)
            {
                index = text.IndexOf("s", index + 1);
                if (index == -1)
                {
                    break;
                }
                listBox1.Items.Add(index + 1 + "---我写的");
            }

        }
    }
}
