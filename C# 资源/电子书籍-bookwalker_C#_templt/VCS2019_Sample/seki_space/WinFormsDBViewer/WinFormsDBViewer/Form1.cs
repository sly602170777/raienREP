using System.Data;
using System.Windows.Forms;

namespace WinFormsDBViewer
{
    public partial class Form1 : Form
    {
        public Form1 ()
        {
            InitializeComponent ();
        }

        private void button1_Click (object sender, EventArgs e)
        {
            MessageBox.Show ("first form", "first form");
        }

        private void Form1_Load (object sender, EventArgs e)
        {
            LoadUserData (); // 窗体加载时调用LoadUserData方法加载用户数据
        }
        // <summary>
        // 加载用户数据到DataGridView的方法
        // </summary>
        private void LoadUserData ()
        {
            try
            {
                // 1. 定义SQL查询语句，从UserTable表中查询所有数据
                string sqlQuery = "SELECT * FROM BaseInfo"; // 假设您的用户表名为 UserTable

                // 2. 调用DatabaseHelper共同类中的GetDataTable方法，执行查询并获取DataTable
                DataTable userDataTable = DatabaseHelper.GetDataTable (sqlQuery);
                var a = textBox1.Text;
                MessageBox.Show (a, "text1");

                // 3. 检查DataTable是否成功获取到数据
                if (userDataTable != null)
                {
                    // 4. 将DataTable绑定到DataGridView控件
                    userDataDataGridView.DataSource = userDataTable; // 将获取到的userDataTable设置为userDataDataGridView的数据源

                    // (可选) 调整DataGridView的显示效果，例如自动调整列宽
                    userDataDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // 根据所有单元格内容自动调整列宽

                }
                else
                {
                    // 5. 如果DataTable为null，表示数据加载失败，弹出提示信息
                    MessageBox.Show ("加载用户数据失败，请检查数据库连接和用户表是否存在。", "数据加载失败", MessageBoxButtons.OK, MessageBoxIcon.Warning); // 弹出警告提示框
                }
            }
            catch (Exception ex)
            {
                // 6. 捕获窗体加载过程中可能发生的其他异常
                MessageBox.Show ($"窗体加载时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); // 弹出错误提示框
            }
        }

        /// <summary>
        /// 文本框数据验证
        /// 触发条件: 当控件即将失去焦点，并且需要进行验证时触发。
        /// 通常发生在 Leave 事件之前。Validating 事件允许程序在焦点离开控件前，检查控件中的数据是否有效。

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxAge_Validating (object sender, System.ComponentModel.CancelEventArgs e)
        {
            int age;
            if (!int.TryParse (textBox1.Text, out age) || age <= 0 || age > 100)
            {
                e.Cancel = true; // 阻止焦点离开	
                MessageBox.Show (textBox1.Text, "请输入有效的年龄 (1-150之间的整数)");
            }
            else
            {
                MessageBox.Show (textBox1.Text, ""); // 清除错误提示	
            }
        }
    }
}

