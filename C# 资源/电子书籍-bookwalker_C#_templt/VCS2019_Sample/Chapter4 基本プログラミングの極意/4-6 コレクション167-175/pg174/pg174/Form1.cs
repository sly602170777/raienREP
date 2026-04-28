using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg174
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        

        Dictionary<string, ValueTuple<string,string>> dic;

        private void Form1_Load(object sender, EventArgs e)
        {
            dic = new Dictionary<string, ValueTuple<string, string>>();
            dic.Add("JP", ("Japan","日本"));
            dic.Add("CN", ("China", "中国"));
            dic.Add("KR", ("Republic of Korea","韓国"));
            dic.Add("GB", ("United Kingdom","イギリス"));
            dic.Add("US", ("United States of America","アメリカ"));
            dic.Add("CA", ("Canada","カナダ"));
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
                label1.Text = dic[key].Item2 ;
            } 
            else
            {
                label1.Text = "値が存在しません";
            }
        }
    }
}
