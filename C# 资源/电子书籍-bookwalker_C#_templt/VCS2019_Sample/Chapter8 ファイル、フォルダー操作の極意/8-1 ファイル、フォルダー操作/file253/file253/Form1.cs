using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file253
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var asm = System.Reflection.Assembly.GetExecutingAssembly();
            var path = System.IO.Path.GetDirectoryName( asm.Location) ;
            textBox1.Text = path;
        }
    }
}
