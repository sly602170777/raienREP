using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui074
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String[] myArray = new string[] {"A4用紙","A3用紙","B5用紙",
                        "B4用紙","修正液","付箋"};
            listBox1.Items.AddRange(myArray);
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            listBox2.SelectionMode = SelectionMode.MultiSimple;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //リストボックス1で選択された項目をリストボックス2に追加
            if (listBox1.SelectedItem !=null)
            {
                foreach (Object myList in listBox1.SelectedItems)
                {
                    listBox2.Items.Add(myList);
                }
            }

            //リストボックス1で選択された項目を削除
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                if (listBox1.GetSelected(i))
                {
                    listBox1.Items.RemoveAt(i);
                }
            }
        }
    }
}
