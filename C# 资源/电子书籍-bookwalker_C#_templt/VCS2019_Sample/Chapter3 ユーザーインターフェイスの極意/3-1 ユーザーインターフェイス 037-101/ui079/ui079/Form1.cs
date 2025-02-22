using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui079
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            monthCalendar1.MaxSelectionCount = 10;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DateTime stDay = monthCalendar1.SelectionStart;
            DateTime edDay = monthCalendar1.SelectionEnd;
            int myDays = edDay.Subtract(stDay).Days + 1;

            label1.Text = stDay.ToLongDateString();
            label2.Text = edDay.ToLongDateString();
            label3.Text = myDays.ToString();
        }
    }
}
