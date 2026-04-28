using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui049
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2(); //Form2のインスタンスを作成
            newForm.ShowDialog(); //Form2をモーダルで表示
            label1.Text = newForm.textBox1.Text; //Form2のテキストボックスの値を参照
        }
    }
}
