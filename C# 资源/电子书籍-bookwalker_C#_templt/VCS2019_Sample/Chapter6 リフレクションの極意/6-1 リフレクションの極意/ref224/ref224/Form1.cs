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

namespace ref224
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
            // プライベートフィールドに設定
            string name = "マスダトモアキ";
            SetField(obj, "_Name", name);

            textBox1.Text = name;
            textBox2.Text = obj.Name;
        }

        public void SetField<T>(T target, string name, object value)
        {
            Type t = typeof(T);
            var pi = t.GetTypeInfo().GetDeclaredField(name);
            pi.SetValue(target, Convert.ChangeType(value, pi.FieldType));
        }
    }



    [Table("サンプルクラス")]
    public class SampleClass
    {
        
        public int ID { get; set; }
        /// プライベートフィールドのみ
        private string _Name = "sample";
        public string Name { get => _Name; }

        public string Address { get; set; }

        public string ShowData()
        {
            return $"{ID} : {Name} in {Address}";
        }
    }
}
