using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg199
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


        private void Button1_Click(object sender, EventArgs e)
        {
            SampleStruct obj;
            obj.ID = 100;
            obj.Name = "マスダトモアキ";
            obj.Address = "板橋区";
            label1.Text = obj.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SampleClass obj = new SampleClass()
            {
                ID = 100,
                Name = "マスダトモアキ",
                Address = "板橋区"
            };
            label1.Text = obj.ToString();
        }
    }

}
