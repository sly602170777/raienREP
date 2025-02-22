using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg164
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var apli =
                new string[] { "PowerPoint", "Word", "Excel", "Access" };

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox1.Items.AddRange(apli);  //ソート前
            Array.Sort(apli);               //昇順でソート
            listBox2.Items.AddRange(apli);
            Array.Reverse(apli);            //現在と逆順でソート
            listBox3.Items.AddRange(apli);
        }
    }
}
