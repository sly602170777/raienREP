using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg172
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        Dictionary<string, string> dic;

        private void Form1_Load(object sender, EventArgs e)
        {
            dic = new Dictionary<string, string>()
            {
                {"JP", "Japan" },
                {"CN", "China"},
                {"KR", "Republic of Korea" },
                {"GB", "United Kingdom"},
                {"US", "United States of America"},
                {"CA", "Canada" },
            };

            // リストへ表示
            foreach ( var it in dic )
            {
                listBox1.Items.Add($"{it.Key} {it.Value}");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var key = textBox1.Text;
            if ( dic.ContainsKey( key ) == true )
            {
                label1.Text = dic[key];
            } 
            else
            {
                label1.Text = "値が存在しません";
            }
        }
    }
}
