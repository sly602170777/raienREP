using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg173
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Dictionary<int, string> dic = new Dictionary<int, string>();

        private void Button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            string text = textBox2.Text;
            // キーと値を追加
            dic.Add(id, text);

            //dic[id]=text; //インデクサ使用
            
            // 表示
            listBox1.Items.Clear();
            foreach ( var it in dic )
            {
                listBox1.Items.Add($"{it.Key} {it.Value}");
            }
        }
    }
}
