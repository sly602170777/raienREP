using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg167
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> lst = new List<string>(); //List<T>のインスタンス作成
        List<string> stuLst = new List<string>(); //List<T>のインスタンス作成
        Student s1 = new Student("Last Class", "W00ang", 18);
        Student s2 = new Student("Last Class2", "Seking", 18);
        List<Student> lstStudent = new List<Student>();
        private void Button1_Click(object sender, EventArgs e)
        {
            stuLst.Add(s2.name);
            stuLst.Add(s1.name);
            var list1 = stuLst.ToList();
            
            // 項目をひとつ追加
            lst.Add(DateTime.Now.ToString());
            // 結果をリストボックスに表示
            listBox1.Items.Clear();

            //全部添加
            //listBox1.Items.AddRange(lstStudent.ToArray());

            for (int i = 0; i < lst.Count; i++)
            {
                //listBox1.Items.AddRange(lst.ToArray());
            }

            //listBox1.Items.Add(lstStudent.ToString());

            listBox1.Items.AddRange(lst.ToArray());

            //条件检索
            var list2 = list1.Where(a => a.StartsWith("Sek")).ToList();
            listBox1.Items.AddRange(list2.ToArray());

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Student s1 = new Student("Last Class","W00ang",18);
            List<Student> lstStudent = new List<Student>();
            listBox1.Items.Add(s1);
            // 項目をすべて削除
            lst.Clear();
            // 結果をリストボックスに削除
            listBox1.Items.Clear();
            listBox1.Items.AddRange(lst.ToArray());
            //listBox1.Items.RemoveAt(1);
        }
    }
}
