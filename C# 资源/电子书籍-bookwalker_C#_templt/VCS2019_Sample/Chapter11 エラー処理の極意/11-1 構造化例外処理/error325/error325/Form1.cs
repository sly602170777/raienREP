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

namespace error325
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text);
            int b = int.Parse(textBox2.Text);

            try
            {
                if (b == 0)
                {
                    throw new SampleException("0で除算はできません");
                }
                int ans = a / b;
                MessageBox.Show($"ans: {ans}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー発生");
            }
        }
    }

    public class SampleException : Exception
    {
        public SampleException() : base()
        {
        }
        public SampleException(string msg) :
            base(msg)
        {
        }
        public SampleException(string msg, Exception inner) :
            base(msg, inner)
        {
        }
    }
}
