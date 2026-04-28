using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg168
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // 宣言と同時に初期化する
            var lst = new List<string>
            {
                "ティラノサウルス",
                "ブラキオサウルス",
                "トリケラトプス",
                "ヴェロキラプトル",
                "マイアサウラ"
            };
            label1.Text = lst[0];
            label2.Text = lst.Count.ToString();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(lst.ToArray());
        }
    }
}
