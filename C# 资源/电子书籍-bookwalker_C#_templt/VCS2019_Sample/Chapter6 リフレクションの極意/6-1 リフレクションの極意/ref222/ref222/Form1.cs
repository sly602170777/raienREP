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

namespace ref222
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
            // プロパティの属性を取得
            listBox1.Items.Clear();
            foreach ( var pi in typeof(SampleClass).GetProperties())
            {
                var at = pi.GetCustomAttribute<DisplayNameAttribute>();
                listBox1.Items.Add($"{pi.Name} {at.DisplayName}");
            }
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
