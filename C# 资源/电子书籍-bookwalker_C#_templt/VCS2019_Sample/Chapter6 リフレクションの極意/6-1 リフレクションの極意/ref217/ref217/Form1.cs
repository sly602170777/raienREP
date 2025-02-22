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

namespace ref217
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var mi = typeof(SampleClass).GetMethod(name);
            if ( mi == null )
            {
                textBox2.Text = "メソッドが見つかりませんでした";
            }
            else
            {
                var text = $@"
メソッド名 : {mi.Name}
引数の数 : {mi.GetParameters().Length}
戻り値の型 : {mi.ReturnType.ToString()}
";
                textBox2.Text = text;

            }
        }
    }
    public class SampleClass
    {
        private string _name = "";

        public int ID { get; set; }
        public string Name { get => _name; }
        public string Address { get; set; }

        public SampleClass( string name )
        {
            _name = name;
        }
        public string ShowData()
        {
            return $"{ID} : {Name} in {Address}";
        }
        public void ChangeName( string name )
        {
            _name = name;
        }
    }
}
