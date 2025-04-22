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

namespace ref223
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
            // メソッドの属性を取得
            var mi = typeof(SampleClass).GetMethod("ShowData");
            var attr = mi.GetCustomAttribute<DisplayAttribute>();
            textBox1.Text = attr.Description;
        }
    }

    [Table("サンプルクラス")]
    public class SampleClass
    {
        
        [Key]
        [DisplayName("識別子")]
        public int ID { get; set; }
        [DisplayName("名前")]
        public string Name { get; set; }
        [DisplayName("住所")]
        public string Address { get; set; }

        [Display(Description = "フォーマットした文字列を取得する")]
        public string ShowData()
        {
            return $"{ID} : {Name} in {Address}";
        }
        public void ChangeName( string name )
        {
            this.Name = name;
        }
    }
}
