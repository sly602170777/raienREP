using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg152
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "オレンジ":
                    BackColor = Color.Orange;
                    break;
                case "ブルー":
                    BackColor = Color.Blue;
                    break;
                case "イエロー":
                    BackColor = Color.Yellow;
                    break;
                default:
                    BackColor = Color.Empty;
                    break;
            }
        }
    }
}
