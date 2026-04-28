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

namespace wpf389
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
            var s = "";
            if (rb1.IsChecked.Value) s = "国語";
            if (rb2.IsChecked.Value) s = "算数";
            if (rb3.IsChecked.Value) s = "理科";
            if (rb4.IsChecked.Value) s = "社会";
            if (rb5.IsChecked.Value) s = "プログラミング";
            text.Text = s;
        }
    }
}
