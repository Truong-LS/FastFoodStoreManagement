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
using View;

namespace View
{
    /// <summary>
    /// Interaction logic for ShiffManagementWindow.xaml
    /// </summary>
    public partial class ShiffManagementWindow : Window
    {
        public ShiffManagementWindow()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new CreateShiffWindow
            {
                Owner = this
            };
            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                // Người dùng bấm Create trong dialog
                // Load lại DataGrid hoặc feedback
            }
        }

        private void BtnShift_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ShiffManagementWindow();
        }

        private void BtnCoupon_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CouponManagementWindow();
        }
    }
}
