using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui089
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 1000;
            progressBar1.Value = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 1000; i++)
            {
                System.Threading.Thread.Sleep(10);
                progressBar1.Value = i;
                progressBar1.Refresh();  //プログレスバーを再描画する
            }    
        }
    }
}
