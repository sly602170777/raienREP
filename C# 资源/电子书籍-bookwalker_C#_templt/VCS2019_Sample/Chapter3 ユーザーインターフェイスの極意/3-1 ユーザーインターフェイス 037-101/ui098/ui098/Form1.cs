using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui098
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 1;             //最小値の設定
            numericUpDown1.Maximum = 100;           //最大値の設定
            numericUpDown1.Value = 50;              //現在値の設定
            numericUpDown1.Increment = 1;           //増減値の設定

        }
    }
}
