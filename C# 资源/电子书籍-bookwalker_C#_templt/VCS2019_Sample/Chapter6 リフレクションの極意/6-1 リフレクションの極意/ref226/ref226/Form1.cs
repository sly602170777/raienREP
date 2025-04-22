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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ref226
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
            textBox1.Text = obj.Name;
            textBox2.Text = (string)Invoke(obj, "ShowData", new object[] { });
        }

        public object Invoke<T>(T target, string name, params object[] args)
        {
            Type t = typeof(T);
            var lst = new List<Type>();
            foreach (var it in args)
                lst.Add(it.GetType());
            var mi = t.GetTypeInfo().GetDeclaredMethod(name);
            return mi.Invoke(target, args);
        }
    }



    [Table("サンプルクラス")]
    public class SampleClass
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        /// プライベートメソッド
        private string ShowData()
        {
            return $"{ID} : {Name} in {Address}";
        }
    }
}
