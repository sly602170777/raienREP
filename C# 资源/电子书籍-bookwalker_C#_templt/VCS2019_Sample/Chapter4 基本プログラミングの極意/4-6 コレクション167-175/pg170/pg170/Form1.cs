using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg170
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lst = new List<string>
            {
                "ティラノサウルス",
                "ブラキオサウルス",
                "トリケラトプス",
                "ヴェロキラプトル",
                "マイアサウラ"
            };
            listBox1.Items.AddRange(lst.ToArray());
        }

        List<string> lst ;

        private void Button1_Click(object sender, EventArgs e)
        {
            // 先頭の項目を削除
            lst.RemoveAt(0);
            // 表示する
            listBox1.Items.Clear();
            listBox1.Items.AddRange(lst.ToArray());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // 項目を指定して削除
            lst.Remove("トリケラトプス");
            // 表示する
            listBox1.Items.Clear();
            listBox1.Items.AddRange(lst.ToArray());
        }
    }
}
