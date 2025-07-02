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
using View.ManagerView.Control;
using View.View.ManagerView.Control;

namespace View.View.ManagerView
{
    /// <summary>
    /// Interaction logic for StaffMainWindow.xaml
    /// </summary>
    public partial class StaffMainWindow : Window
    {
        private Brush defaultColor = Brushes.Gold;
        private Brush selectedColor = Brushes.LightGreen;
        public StaffMainWindow()
        {
            InitializeComponent();
        }

        private void BtnShiffMangement_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCouponManagement_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnStockMangement(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new StockManagementControl();
        }

        private void BtnStockinStockout_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new StockInStockOutControl();
        }

        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMenuManager_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAccountManager_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new AccManagementControl();
        }
    }
}
