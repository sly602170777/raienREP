using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui081
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 左揃えToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (左揃えToolStripMenuItem.Checked == true)
            {
                textBox1.TextAlign = HorizontalAlignment.Left;
                左揃えToolStripMenuItem.Checked = false;
            }
            
        }

        private void 中央揃えToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Center;
        }

        private void 右揃えToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Right;
        }
    }
}
