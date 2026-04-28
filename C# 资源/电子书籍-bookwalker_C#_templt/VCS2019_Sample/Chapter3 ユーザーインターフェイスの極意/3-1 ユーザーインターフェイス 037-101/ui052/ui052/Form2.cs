using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui052
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //ラベルに製品名、バージョン、会社名を表示する
            label1.Text = Application.ProductName;
            label2.Text = "バージョン："+Application.ProductVersion;
            label3.Text = Application.CompanyName;
        }
    }
}
