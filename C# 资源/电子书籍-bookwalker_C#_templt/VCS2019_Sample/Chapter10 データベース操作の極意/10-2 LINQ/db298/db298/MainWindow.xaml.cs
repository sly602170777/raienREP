using System;
using System.Collections.Generic;
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

namespace db298
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var ent = new sampledbEntities();
            var q = from b in ent.Book
                    select b;
            dg.ItemsSource = q.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /// 要素が含まれているかチェックする
            var ent = new sampledbEntities();
            var x = ent.Book.Any(t => t.ID == 100);
            MessageBox.Show($"真偽: {x}");
        }
    }
}
