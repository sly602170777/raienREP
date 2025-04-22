using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace debug349
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("インデント前");
            Debug.Indent();
            Debug.WriteLine("インデント1回目");
            Debug.Indent();
            Debug.WriteLine("インデント2回目");
            Debug.Unindent();
            Debug.WriteLine("インデントを戻す");
            Debug.Unindent();
            Debug.WriteLine("インデントを戻す");
        }
    }
}
