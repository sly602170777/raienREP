using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace ref220
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var obj = new SampleClass()
            {
                ID = 100,
                Name = "マスダトモアキ",
                Address = "板橋区"
            };
            // 通常のメソッドで取得
            textBox1.Text = obj.ShowData();
            // リフレクションでメソッドを実行
            var mi = typeof(SampleClass).GetMethod("ShowData");
            var v = mi.Invoke(obj, new object[] { }) as string;
            textBox2.Text = v;
        }
    }
    public class SampleClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public string ShowData()
        {
            return $"{ID} : {Name} in {Address}";
        }
        public void ChangeName( string name )
        {
            this.Name = name;
        }
    }
}
