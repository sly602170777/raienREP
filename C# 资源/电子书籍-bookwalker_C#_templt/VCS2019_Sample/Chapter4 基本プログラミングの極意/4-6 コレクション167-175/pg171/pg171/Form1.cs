using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg171
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        List<string> lst = new List<string>
            {
                "ティラノサウルス",
                "ブラキオサウルス",
                "トリケラトプス",
                "ヴェロキラプトル",
                "マイアサウラ"
            }; 

        private void Form1_Load(object sender, EventArgs e)
        {
           
            listBox1.Items.AddRange(lst.ToArray());
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // リスト全体をコピー
            var lst2 = lst.ToList();
            // 表示する
            listBox1.Items.Clear();
            listBox1.Items.AddRange(lst.ToArray());
            listBox2.Items.Clear();
            listBox2.Items.AddRange(lst2.ToArray());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // 検索しながらコピー
            var lst2 = lst.Where(t => t.EndsWith("ウルス")).ToList();
            // 表示する
            listBox1.Items.Clear();
            listBox1.Items.AddRange(lst.ToArray());
            listBox2.Items.Clear();
            listBox2.Items.AddRange(lst2.ToArray());
        }
    }
}
