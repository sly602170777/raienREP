using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg195
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
            /// 継承したクラスを利用
            var obj = new SubSampleClass()
            {
                Name = "マスダトモアキ",
                Age = 51,
                Address = "板橋区",
                Tel = "090-XXXX-YYYY"
            };
            label1.Text = obj.Name;
            label2.Text = obj.Age.ToString();
            label3.Text = obj.Address;
            label4.Text = obj.Tel;
        }
    }

    // SampleClassクラス
    public class SampleClass
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public SampleClass() { }
        /// コンストラクター
        public SampleClass( string name, int age, string address )
        {
            this.Name = name;
            this.Age = age;
            this.Address = address;
        }
    }
    // SubSampleClass 
    public class SubSampleClass : SampleClass
    {
        public string Tel { get; set; }

        public SubSampleClass () { }
        /// コンストラクター
        public SubSampleClass(string name, int age, string address, string tel )
            : base( name, age, address)
        {
            this.Tel = tel;
        }
    }
}
