using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui083
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void 太字ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (太字ToolStripMenuItem.Checked)
            {
                textBox1.Font = new Font(textBox1.Font, FontStyle.Regular);
                太字ToolStripMenuItem.Checked = false;
            }
            else
            {
                textBox1.Font = new Font(textBox1.Font, FontStyle.Bold);
                太字ToolStripMenuItem.Checked = true;
            }
        }
    }
}
