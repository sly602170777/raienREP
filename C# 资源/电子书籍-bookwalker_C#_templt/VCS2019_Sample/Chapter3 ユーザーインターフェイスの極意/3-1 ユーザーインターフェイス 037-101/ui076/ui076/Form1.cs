using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui076
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("レモン");
            comboBox1.Items.Add("リンゴ");
            comboBox1.Items.Add("ブドウ");
            comboBox1.Items.Add("メロン");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                label1.Text="選択されていません";
            }
            else
            {
                label1.Text=comboBox1.SelectedItem.ToString();
            }
        }
    }
}
