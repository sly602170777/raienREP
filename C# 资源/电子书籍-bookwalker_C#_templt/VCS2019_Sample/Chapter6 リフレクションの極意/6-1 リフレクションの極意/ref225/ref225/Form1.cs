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

namespace ref225
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
                Address = "板橋区"
            };
            // プライベートプロパティに設定
            string name = "マスダトモアキ";
            SetProperty(obj, "Name", name);

            textBox1.Text = name;
            textBox2.Text = obj.Name;
        }

        public void SetProperty<T>(T target, string name, object value, params object[] args)
        {
            Type t = typeof(T);
            var pi = t.GetRuntimeProperty(name);
            pi = t.GetTypeInfo().GetDeclaredProperty(name);
            pi.SetValue(target, Convert.ChangeType(value, pi.PropertyType), args);
        }
    }



    [Table("サンプルクラス")]
    public class SampleClass
    {
        public int ID { get; set; }
        /// プライベートプロパティのみ
        public string Name { get; private set; }
        public string Address { get; set; }
        public string ShowData()
        {
            return $"{ID} : {Name} in {Address}";
        }
    }
}
