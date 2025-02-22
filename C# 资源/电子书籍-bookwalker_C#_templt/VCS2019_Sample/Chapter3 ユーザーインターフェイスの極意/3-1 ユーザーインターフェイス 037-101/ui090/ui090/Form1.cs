using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui090
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //ノードのフルパスを取得
            label1.Text = treeView1.SelectedNode.FullPath;
        }
        //東京本社 ||

        private void Button2_Click(object sender, EventArgs e)
        {
            TreeNode selectNode = treeView1.SelectedNode;
            foreach (var item in treeView1.Nodes)
            {
                Boolean a = textBox1.Text.Contains(item.ToString());
                if (textBox1.Text == "" || a)
                {
                    return;
                }
            }
            


            if (selectNode==null)
            {
                MessageBox.Show("追加場所を選択してください","通知");
                return;
            }
            //ノードの追加
            selectNode.Nodes.Add(new TreeNode(textBox1.Text));
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            TreeNode selectNode = treeView1.SelectedNode;
            if (selectNode==null)
            {
                MessageBox.Show("削除項目を選択してください", "通知");
            }
            else
            {
                //ノードを削除
                selectNode.Remove();
            }
                 
        }
    }
}
