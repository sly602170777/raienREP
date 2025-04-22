using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace db281
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

private void Button_Click(object sender, RoutedEventArgs e)
{
    /// 接続文字列
    string cnstr = "data source=.;initial catalog=sampledb;integrated security=True";
    /// EntityConnectionの作成
    var esb = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder();
    esb.Provider = "System.Data.SqlClient";
    esb.ProviderConnectionString = cnstr;
    esb.Metadata = "res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl";
    var cn = new System.Data.Entity.Core.EntityClient.EntityConnection(esb.ToString());
    // EntityConnectionのインスタンスを渡す
    var ent = new sampledbEntities(cn);
    dg.ItemsSource = ent.Person.ToList();
        }
    }

public partial class sampledbEntities : DbContext
{
    /// <summary>
    /// コネクションを渡すコンストラクタ
    /// </summary>
    /// <param name="existingConnection"></param>
    public sampledbEntities(DbConnection existingConnection) :
        base(existingConnection, true)
    {
    }
}
}
