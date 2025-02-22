using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg193
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _obj = new SampleClass("河南省固始县");
            // イベントハンドラを設定する，左边事件，右边是方法，且都不带参数
            _obj.OnChangeName += _obj_OnChangeName;
            label1.Text = _obj.Name;
            label2.Text = "";
        }

        private void _obj_OnChangeName(DateTime obj)
        {
            label1.Text = _obj.Name;
            label2.Text = "Nameを変更した " + obj.ToString();
        }

        SampleClass _obj;

        private void Button1_Click(object sender, EventArgs e)
        {
            // イベントを発生させる，修改名字，触发事件
            _obj.Name = "固始叫俏吧县";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // イベントハンドラを削除する  删除后 事件则为Null
            _obj.OnChangeName -= _obj_OnChangeName;
            _obj.Name = "河南省俏吧县";
        }
    }

    // SampleClassクラス 类中包含一个事件
    public class SampleClass
    {
        private string _name;
        private DateTime _time;

        //クラスのコンストラクター
        public SampleClass(string name)
        {
            _name = name;
        }
        // イベントの定義
        public event Action<DateTime> OnChangeName;
        // Name プロパティの変更
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                _time = DateTime.Now;
                // インベントを発生させる，调用事件 带参数
                if (OnChangeName != null)
                {
                    OnChangeName(_time);
                }
                // 以下のように1行でも書ける
                // OnChangeName?.Invoke(_time);
            }
        }
    }
}
