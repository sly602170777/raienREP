using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui043
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            //フォームをモーダルで表示
            //フォーム表示中は別のフォームを選択できない
            newForm.ShowDialog();
            //newForm.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            //フォームをモードレスで表示
            //フォーム表示中でも別のフォームを選択できる
            newForm.Show();
        }
    }
}
