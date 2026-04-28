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

namespace ref215
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
            var pi = typeof(SampleClass).GetProperty(name);
            if (pi == null)
            {
                textBox2.Text = "プロパティが見つかりませんでした";
            }
            else
            {
                var text = $@"
プロパティ名 : {pi.Name}
型 : {pi.PropertyType.ToString()}
読み取り : {pi.CanRead}
書き込み : {pi.CanWrite}
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

        public SampleClass(string name, int id)
        {
            _name = name;
            this.ID = id;
        }
        public string ShowData()
        {
            return $"{ID} : {Name} in {Address}";
        }
        public void ChangeName(string name)
        {
            _name = name;

        }
    }
}
