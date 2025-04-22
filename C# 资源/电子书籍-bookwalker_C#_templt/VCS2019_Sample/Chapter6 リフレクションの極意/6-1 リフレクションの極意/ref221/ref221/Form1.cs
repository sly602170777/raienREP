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

namespace ref221
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
            // クラスの属性を取得
            var at = typeof(SampleClass).GetCustomAttribute<TableAttribute>();
            textBox1.Text = at.Name;
        }
    }

    [Table("サンプルクラス")]
    public class SampleClass
    {
        
        [Key]
        [Column("識別子")]
        public int ID { get; set; }
        [Column("名前")]
        public string Name { get; set; }
        [Column("住所")]
        public string Address { get; set; }

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
