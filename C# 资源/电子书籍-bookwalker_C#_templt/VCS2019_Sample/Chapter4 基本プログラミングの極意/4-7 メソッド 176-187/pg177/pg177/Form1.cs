using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg177
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int x = -10;
            int y = 20;
            int z = Plus(x, y);
            label1.Text = z.ToString();

            string s3 = append(100,200);
            label2.Text = s3;

            var p = MakePerson("マスダトモアキ", 51, "板橋区");
            label3.Text = $"{p.Name} ({p.Age}) in {p.Address}";
        }

        /// 数値を返すメソッド
        int Plus( int x , int y )
        {
            if ( x < 0 || y < 0 )
            {
                return 0;
            }
            else
            {
                return x + y;
            }
        }

        /// 文字列を返すメソッド
        string append( int x, int y ) 
        {
            int z = Plus(x, y);
            return $"{x} と {y} を渡した結果 {z}";
        }

        /// オブジェクトを返すメソッド
        Person MakePerson( string name, int age, string address )
        {
            var p = new Person()
            {
                Name = name,
                Age = age,
                Address = address,
            };
            return p;
        }

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }
        }
    }
}
