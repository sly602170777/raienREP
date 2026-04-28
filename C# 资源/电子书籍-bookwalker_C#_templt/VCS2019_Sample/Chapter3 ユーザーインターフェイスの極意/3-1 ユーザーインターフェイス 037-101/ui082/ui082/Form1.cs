using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui082
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 左揃えToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Left;
            左揃えToolStripMenuItem.Enabled = false;
            中央揃えToolStripMenuItem.Enabled = true;
            右揃えToolStripMenuItem.Enabled = true;

        }

        private void 中央揃えToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Center;
            左揃えToolStripMenuItem.Enabled = true;
            中央揃えToolStripMenuItem.Enabled = false;
            右揃えToolStripMenuItem.Enabled = true;
        }

        private void 右揃えToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Right;
            左揃えToolStripMenuItem.Enabled = true;
            中央揃えToolStripMenuItem.Enabled = true;
            右揃えToolStripMenuItem.Enabled = false;

        }
    }
}
