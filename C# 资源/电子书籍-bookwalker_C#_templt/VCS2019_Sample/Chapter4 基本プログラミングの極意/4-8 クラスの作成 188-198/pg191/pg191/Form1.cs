using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg191
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var obj = new SampleClass("秀和太郎");
            /// 引数なしのメソッド呼び出し
            label1.Text = obj.ShowData();
            /// 引数ありのメソッド呼び出し
            label2.Text = obj.GetName("御中");
        }
    }

    // SampleClassクラス
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

        /// 引数のないメソッド
        public string ShowData()
        {
            // 最初の5桁のみ表示する
            return _name + " " + _id.Substring(0, 5) + "...";
        }

        /// 引数のあるメソッド
        public string GetName( string post )
        {
            // ポストフィックスを付ける
            return _name + " " + post;
        }
    }
}
