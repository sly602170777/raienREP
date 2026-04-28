using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui095
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int pos;
            richTextBox1.SelectionStart = richTextBox1.SelectionStart +
                                  richTextBox1.SelectionLength;
            richTextBox1.SelectionLength = 0;
            richTextBox1.Focus();
            pos = richTextBox1.Find(textBox1.Text, richTextBox1.
                    SelectionStart,RichTextBoxFinds.None);

        }
    }
}
