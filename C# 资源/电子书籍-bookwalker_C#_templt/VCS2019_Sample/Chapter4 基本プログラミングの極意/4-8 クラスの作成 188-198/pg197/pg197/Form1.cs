using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg197
{
    public partial class Form1 : Form
    {
        public Form1()
        {
 
            InitializeComponent();

        }

        // 読み取り専用クラス
        public class ReadOnly<T,S>
        {
            private T _value;
            private S _kv;
            public ReadOnly( T value ) 
            {
                _value = value; 
            }
            public ReadOnly(T value,S KV)
            {
                _kv = KV;
            }
      //      public T Value => _value; 同下
            public T Value { get => _value; }
        }

        public void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var name = new ReadOnly<string,int>("masuda");
            var age = new ReadOnly<int,int>(51);

            //name.Value = "ww";
            label1.Text = name.Value;
            label2.Text = age.Value.ToString();

            //label3.Text = new ReadOnly<string ,int>("w",5).Value;  --null
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            string a = "マスダ";
            string b = "智明";

            Swap(ref a, ref b);

            label1.Text = a;
            label2.Text = b;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //DataSet Ds = new DataSet();
            ////this.Data1.DataSource = Ds;
            ////this.Data1.DataMember = "T_Class";

            //SqlDataAdapter sda = new SqlDataAdapter("", conn);

            //sda.Fill(Ds, "T_Class");

            ////使用DataSet绑定时，必须同时指明DateMember 
            //this.dataGridView1.DataSource = Ds;
            //this.dataGridView1.DataMember = "T_Class";

            ////也可以直接用DataTable来绑定 
            //this.dataGridView1.DataSource = Ds.Tables["T_Class"];

            string sqlParmaQuery = @"select * from AAA where ID =@param1 or name=@param2";
            SqlParameter[] cachedParms = new SqlParameter[]
            {
                    new SqlParameter("@param1",4521),
                    new SqlParameter("@param2","tt")
            };
            DataTable dt = SqlHelper.ExcuteParamQuery(sqlParmaQuery, cachedParms);
           // DataTable dt = new DataTable();//创建DataTable对象
            dt.Columns.Add("列一", System.Type.GetType("System.Int32"));
            data1.DataSource = dt;
            data2.DataSource = dt;
            data1.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.InsetDouble;
            data1.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.Inset;
            data1.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Inset;
            data1.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.InsetDouble;
            // data1.Columns = dt.Columns;

            data1.AllowUserToAddRows = false;  //不同意用户添加行，这样就不会出现最后一行空白行，大多数时候表格只是用来展示数据而非用户录入数据（录入数据神马的用EXCEL更方便吧）
            data1.BackgroundColor = Color.White;  //背景色设置为白色，至少比默认的灰色要好看
            data1.RowHeadersVisible = true;　　//行头不显示，这个对于不用选择一整行的操作时非常有用，因为行头的显示非常
            data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void coBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           // List<string> list = new List<string> { "A", "B" };

           // this.coBox.SelectedItem.ToString();
           // ControllerHelper.AddItem(coBox, list, true);
            if (this.coBox.Text== "高尔夫球")
            {
                data1.Show();
                data2.Visible = false;
                //this.data2.IsMirrored = true;
            }
            else
            {
                data2.Show();
                data1.Visible = false;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //添加下拉菜单的item 
            string[] arr = { "高尔夫球", "乒乓球", "羽毛球", "排球" };

            for (int i = 0; i < arr.Length; i++)

            {

                this.coBox.Items.Add(arr[i]);

            }
            //只可选择不可编辑
            //this.coBox.Items.Add("WE");
            //this.coBox.Items.Add("Ws");
            this.coBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }


    }

}
