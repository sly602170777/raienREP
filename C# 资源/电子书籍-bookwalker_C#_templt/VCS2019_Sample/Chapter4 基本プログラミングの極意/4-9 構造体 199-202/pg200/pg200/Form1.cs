using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg200
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        struct SampleStruct
        {
            public int ID;
            public string Name;
            public string Address;
            public override string ToString()
            {
                return $"構造体 {ID} : {Name} in {Address}";
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // 配列を利用
            var ary = new SampleStruct[3];
            ary[0].ID = 100;
            ary[0].Name = "マスダトモアキ";
            ary[0].Address = "板橋区";
            ary[1].ID = 200;
            ary[1].Name = "秀和太郎";
            ary[1].Address = "中央区";
            ary[2].ID = 300;
            ary[2].Name = "極意はなこ";
            ary[2].Address = "北海道";

            listBox1.Items.Clear();
            foreach ( var it in ary )
            {
                listBox1.Items.Add(it.ToString());
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // コレクションを利用
            var lst = new List<SampleStruct>();
            lst.Add(new SampleStruct()
            {
                ID = 100,
                Name = "マスダトモアキ",
                Address = "板橋区"
            });
            lst.Add(new SampleStruct()
            {
                ID = 200,
                Name = "秀和太郎",
                Address = "中央区"
            });
            lst.Add(new SampleStruct()
            {
                ID = 300,
                Name = "極意はなこ",
                Address = "北海道"
            });

            listBox1.Items.Clear();
            foreach (var it in lst)
            {
                listBox1.Items.Add(it.ToString());
            }
        }
    }

}
