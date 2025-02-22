using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg187
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // “à•”’è‹`‚³‚ê‚½ŠÖ”
            int add( int x, int y )
            {
                return x + y;
            }

            int a = int.Parse(textBox1.Text);
            int b = int.Parse(textBox2.Text);
            int ans = add(a, b);
            label1.Text = ans.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // “à•”’è‹`‚³‚ê‚½ƒ‰ƒ€ƒ_®
            Func<int, int, int> add = (x, y) => x + y;

            int a = int.Parse(textBox1.Text);
            int b = int.Parse(textBox2.Text);
            int ans = add(a, b);
            label1.Text = ans.ToString();
        }
    }
}
