using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg128
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int i = 30;
            float s;
            long x = i;                     //暗黙の型変換

            double d = 123.456;
            string str = "121.234355";
            label3.Text = d.ToString();
            i = (int)d;                     //キャスト（桁落ちする）
            s = Convert.ToSingle(str);
            label4.Text = s.ToString();     //ラベルに表示

            object obj = i;                 //暗黙の型変換
            obj = "Visual C# 2019";
            string stringX = (string)obj;   //強制的にキャスト
            string stringY = obj as string; //キャスト
        }
    }
}
