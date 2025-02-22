using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg189
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var obj = new SampleClass("新規のお客様");
            label1.Text = obj.Name;
            label2.Text = obj.ID;
        }
    }

    //SampleClassクラス
    public class SampleClass
    {
        private string _name;
        private string _id;

        //クラスのコンストラクター
        public SampleClass(string name)
        {
            _name = name;
            _id = Guid.NewGuid().ToString();
        }

        public string Name => _name;  // function(string Name) { return _name; }

        public string ID => _id;
    }
}
