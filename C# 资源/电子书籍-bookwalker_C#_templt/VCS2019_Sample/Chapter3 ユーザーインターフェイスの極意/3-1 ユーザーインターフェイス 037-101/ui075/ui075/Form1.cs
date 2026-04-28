using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui075
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] myArray = new string[] { "テニス", "バドミントン",
                "陸上", "柔道", "水泳" };
            checkedListBox1.Items.AddRange(myArray);
            checkedListBox1.SetItemChecked(0, true);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Object myItem in checkedListBox1.CheckedItems)
            {
                listBox1.Items.Add(myItem);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
