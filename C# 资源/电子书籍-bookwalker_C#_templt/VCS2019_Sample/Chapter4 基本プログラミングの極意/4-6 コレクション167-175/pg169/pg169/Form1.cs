using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg169
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> lst = new List<string>();

        private void Button1_Click(object sender, EventArgs e)
        {
            // 項目をひとつ追加
            lst.Add(DateTime.Now.ToString());
            // 表示する
            listBox1.Items.Clear();
            listBox1.Items.AddRange(lst.ToArray());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // 複数項目を追加
            lst.AddRange( new List<string> {
                "---",
                DateTime.Now.ToString(),
                "---" } );
            // 表示する
            listBox1.Items.Clear();
            listBox1.Items.AddRange(lst.ToArray());
        }


    }
}
