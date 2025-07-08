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
using System.Windows.Shapes;
using View.StockManagement.Control;

namespace View.ManagerView
{
    /// <summary>
    /// Interaction logic for StockMangementWIndow.xaml
    /// </summary>
    public partial class StaffMainWindow : Window
    {
        public StaffMainWindow()
        {
            InitializeComponent();
        }

        private void StockManagementButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new StockManagementControl();
        }

        private void StockInStockOutButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new StockInStockOutControl();
        }
    }
}
