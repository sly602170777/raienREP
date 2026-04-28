using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg181
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //实现所有的string数组中每一项小写字母转换成大写字母
        public string[] changeArray(string[] ary)
        {
            var result = new string[ary.Length];
            for (int i = 0; i < ary.Length; i++)
            {
                result[i] = ary[i].ToUpper();
            }
            return result;
        }

        public string[] getStr(string[] arry) 
        {
            var rseult = new string[arry.Length];
            for (int i = 0; i < arry.Length; i++)
            {
                rseult[i] = arry[i].ToString();  
            }
            return rseult;
        }

        public List<string> changeList(List<string> lst)
        {
            var result = new List<string>();
            foreach (var it in lst)
            {
                result.Add(it.ToUpper());
            }
            return result;
        }

        public List<string> getList(List<string> lis)
        {
            var result = new List<string>();
            for (int i = 0; i < lis.Count; i++)
            {
                result[i] = lis[i].ToString();
            }
            return result;
        }

        public List<string> getStu_Name(List<Student> stuList)
        {
            var str = new List<string>();
            for (int i = 0; i < stuList.Count; i++)
            {
                if (i==2)
                {
                    str.Add(stuList[i].hobby);
                }
            }
            return str;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string[] ary =
            {
                "microsoft",
                "apple",
                "ibm",
                "oracle",
                "shuwasystem"
            };
            Student stu1 = new Student("zhang",12,"soccer");
            Student stu2 = new Student("Li", 18, "baoo");
            Student stu3 = new Student("seki", 20, "game");

            List<Student> lit = new List<Student>();
            lit.Add(stu1);
            lit.Add(stu2);
            lit.Add(stu3);
            // ary未被转化时 表示する
            listBox1.Items.Clear();
            foreach (var it in ary)
            {
                listBox1.Items.Add(it);
            }

            //收集所有学生的成员
            foreach (var it in lit)
            {
                listBox1.Items.Add(it);
            }

            // 変換する（配列を引数にしてchangeArrayメソッドを呼び出し、
            // 結果を変数ary2に返す)
            string[] ary2 = changeArray(ary);


            List<string> get_Name = getStu_Name(lit);
            // 表示する
            listBox2.Items.Clear();
            foreach (var it in ary2)
            {
                listBox2.Items.Add(it);
            }

            foreach (var it in get_Name)
            {
                listBox2.Items.Add(it);
            }
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            //リストlstのインスタンス生成と初期化
            List<string> lst = new List<string> 
            {
                "microsoft",
                "apple",
                "ibm",
                "oracle",
                "shuwasystem"
            };
            // 表示する
            listBox1.Items.Clear();
            lst.ForEach(it => listBox1.Items.Add(it));　//ForEachメソッドの使用
            // 変換する
            var lst2 = changeList(lst);　//リストを引数にメソッドを呼び出す
            // 表示する
            listBox2.Items.Clear();
            lst2.ForEach(it => listBox2.Items.Add(it));
        }
    }
}
