using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg196
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            /// 基本クラスの利用
            var obj = new SampleClass()
            {
                Name = "秀和太郎",
                Age = 51,
                Address = "東京都",
            };
            label1.Text = obj.Name;
            label2.Text = obj.ShowData();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            /// 継承クラスの利用
            var obj = new SubSampleClass()
            {
                Name = "秀和太郎",
                Age = 51,
                Address = "東京都",
            };
            label1.Text = obj.Name;
            label2.Text = obj.ShowData();
        }
    }

    // SampleClassクラス
    public class SampleClass
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        // 既存の ToString メソッドをオーバーライドする
        public virtual string ShowData()
        {
            return $"{Name} ({Age}) {Address}";
        }
    }
    public class SubSampleClass : SampleClass
    {
        public override string ShowData()
        {
            return $"{Name} 様 {Age} 歳 IN {Address}";
        }
    }
}
