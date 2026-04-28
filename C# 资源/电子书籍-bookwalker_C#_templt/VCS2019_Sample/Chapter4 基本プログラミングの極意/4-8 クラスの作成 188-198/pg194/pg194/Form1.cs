using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg194
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            /// プロパティを使い初期化
            var obj = new SampleClass()
            {
                Name = "マスダトモアキ",
                Age = 51,
                Address = "板橋区",
            };

            label1.Text = obj.Name;
            label2.Text = obj.Age.ToString();
            label3.Text = obj.Address;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            /// コンストラクタで初期化
            var obj = new SampleClass(
                "マスダトモアキ",
                51,
                "板橋区"
            );
            label1.Text = obj.Name;
            label2.Text = obj.Age.ToString();
            label3.Text = obj.Address;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            /// 名前付き引数でコンストラクタを使い初期化
            var obj = new SampleClass(
                name: "マスダトモアキ",
                age: 51,
                address: "板橋区"
            );
            label1.Text = obj.Name;
            label2.Text = obj.Age.ToString();
            label3.Text = obj.Address;
        }
    }

    // SampleClassクラス

    public class SampleClass
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public SampleClass() { }
        // コンストラクタで初期化
        public SampleClass( string name, int age, string address )
        {
            this.Name = name;
            this.Age = age;
            this.Address = address;
        }
    }
}
