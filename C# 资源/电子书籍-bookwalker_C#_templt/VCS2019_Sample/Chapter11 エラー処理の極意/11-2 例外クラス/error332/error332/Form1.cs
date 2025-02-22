using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace error332
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            var cn = new OleDbConnection();
            try
            {
                cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                    $"Data Source={path}";
                cn.Open();
                MessageBox.Show("データベースに接続しました", "エラー発生");
                cn.Close();
            }
            catch ( OleDbException ex )
            {
                MessageBox.Show(ex.Message, "エラー発生");
            }
        }
    }
}
