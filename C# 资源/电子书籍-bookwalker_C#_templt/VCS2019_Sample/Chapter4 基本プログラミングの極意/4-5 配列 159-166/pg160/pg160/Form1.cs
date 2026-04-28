using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg160
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string[] names = { "AAA", "BBB", "CCC", "JJJ", "FFF" };
            int index = comboBox1.SelectedIndex;
            if (index <0)  //  選択されてない
            {
                label1.Text = "请输入。。。。。";
                return;
            }
            label1.Text = comboBox1.SelectedItem
                + $"---- {names[index]}";
        }
    }
}
