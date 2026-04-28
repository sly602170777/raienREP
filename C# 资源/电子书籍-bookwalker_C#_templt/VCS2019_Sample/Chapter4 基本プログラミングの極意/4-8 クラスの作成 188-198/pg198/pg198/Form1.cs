using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg198
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class SampleClass
        {
            private const int init_id = 100;
            private static int next_id = init_id;

            private int _id;
            private string _name;

            //コンストラクター
            public SampleClass( string name )
            {
                _id = next_id;
                _name = name;
                // とびとびの値にする
                next_id += 50 + new Random().Next(100); 　//50に0以上100未満の乱数加算
            }
            //プロパティ
            public int ID { get => _id; }
            public string Name { get => _name; set => _name = value; }
            
            
            public override string ToString()
            {
                return $"{ID} : {Name}";
            }
            

            // next_id をリセット
            public static void Reset()
            {
                next_id = init_id;
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for ( int i=0; i<10; i++ )
            {
                listBox1.Items.Add(
                    new SampleClass($"名前_{i}"));
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // リセットする
            SampleClass.Reset();
        }
    }
}
