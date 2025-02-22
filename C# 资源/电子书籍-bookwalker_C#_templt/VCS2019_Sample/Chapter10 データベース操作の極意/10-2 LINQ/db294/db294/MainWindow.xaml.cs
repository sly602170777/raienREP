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

namespace db294
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
            var items =
                ent.Book
                .Where(t => t.Title.Contains("逆引き"))
                .ToList();
            dg.ItemsSource = items;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ent = new sampledbEntities();
            int? sum =
                ent.Book
                .Where( t => t.Title.Contains("逆引き"))
                .Sum( t => t.Price );
            MessageBox.Show($"合計は{sum}円です");
        }
    }
}
