using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg190
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SampleClass _obj;
        private void Button1_Click(object sender, EventArgs e)
        {
            // インスタンス生成時にプロパティを指定
            _obj = new SampleClass("新規のお客様");
            label1.Text = _obj.Name;
            label2.Text = _obj.ID;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // 名前の変更
            _obj.Name = "名前を変更する";
            // _obj.ID = "xxxxx";  // IDプロパティは変更できない
            label1.Text = _obj.Name;
            label2.Text = _obj.ID;
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

        /// <summary>
        /// 読み書き可能なプロパティ
        /// </summary>    
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// 読み取り専用のプロパティ
        /// </summary>
        public string ID
        {
            get { return _id; }
        }
    }
}
