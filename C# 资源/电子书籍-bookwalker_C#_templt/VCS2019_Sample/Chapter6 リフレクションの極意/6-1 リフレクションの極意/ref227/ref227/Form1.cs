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

namespace ref227
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // あらかじめ sample.exe を同じフォルダに
            // コピーしておく
            var asm = System.Reflection.Assembly.LoadFrom("sample.exe");
            var t = asm.GetType("sample.SampleClass");
            var obj = System.Activator.CreateInstance(t);
            // リフレクションで取得
            var pi = t.GetProperty("MyName");
            textBox1.Text = pi.GetValue(obj) as string;

        }
    }
}
