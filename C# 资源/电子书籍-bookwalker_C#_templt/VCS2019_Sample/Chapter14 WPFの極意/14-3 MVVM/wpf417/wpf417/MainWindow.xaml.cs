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

namespace wpf417
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

        ViewModel _vm;

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _vm = new ViewModel()
            {
                Item = new Person()
                {
                    ID = 1,
                    Name = "masuda",
                    Age = 50,
                    Address = "板橋区"
                }
            };

            this.DataContext = _vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _vm.Message = $"{_vm.Item.Name} さん、登録をありがとうございます";
            _vm.Items.Add(new Person()
            {
                ID = _vm.Item.ID,
                Name = _vm.Item.Name,
                Age = _vm.Item.Age,
                Address = _vm.Item.Address
            });
        }
    }
}
