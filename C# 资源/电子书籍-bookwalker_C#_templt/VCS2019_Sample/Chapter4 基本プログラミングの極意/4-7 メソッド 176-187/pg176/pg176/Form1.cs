using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg176
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int x = 10;
            int y = 20;
            int z = add(x, y);
            label1.Text = z.ToString();

            string s1 = "Masuda";
            string s2 = "Tomoaki";
            string s3 = append(s1, s2);
            label2.Text = s3;

            var p = new Person()
            {
                Name = "マスダトモアキ",
                Age = 51,
                Address = "板橋区",
            };
            var text = makeStr(p);
            label3.Text = text;
        }


        /// 値を受け取るメソッド
        int add( int x , int y )
        {
            return x + y;
        }
        /// 文字列を受け取るメソッド
        string append( string s1, string s2 )
        {
            return s1 + " " + s2 + " 様宛";
        }

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }
        }
        /// オブジェクトを受け取るメソッド
        string makeStr( Person p )
        {
            return $"{p.Name} ({p.Age}) in {p.Address}";
        }
    }
}
