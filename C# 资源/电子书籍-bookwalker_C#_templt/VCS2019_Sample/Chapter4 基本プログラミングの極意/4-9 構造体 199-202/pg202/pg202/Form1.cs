using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg202
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        struct SampleStruct
        {
            public int ID;
            public string Name;
            public string Address;
            public override string ToString()
            {
                return $"構造体 {ID} : {Name} IN {Address}";
            }
        }

        class SampleClass
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public override string ToString()
            {
                return $"クラス {ID} : {Name} IN {Address}";
            }
        }

        SampleStruct makeStruct( int id, string name, string address ) 
        {
            // 戻り値で返すときは、new 演算子で生成する
            SampleStruct obj = new SampleStruct();
            obj.ID = id;
            obj.Name = name;
            obj.Address = address;
            return obj;
        }

        SampleClass makeClass(int id, string name, string address)
        {
            SampleClass obj = new SampleClass()
            {
                ID = id,
                Name = name,
                Address = address,
            };
            return obj;
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            // 構造体は null にならない
            SampleStruct obj = makeStruct(
                100, "マスダトモアキ", "板橋区");
            label1.Text = obj.ToString();
       }

        private void Button2_Click(object sender, EventArgs e)
        {
            SampleClass obj = makeClass(
                100, "マスダトモアキ", "板橋区");
            label1.Text = obj.ToString();
        }
    }
}
