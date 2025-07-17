using System.Windows;
using System.Windows.Controls;

namespace View
{
    /// <summary>
    /// Interaction logic for ManagerMainWindow.xaml
    /// </summary>
    public partial class ManagerMainWindow : Window
    {
        public ManagerMainWindow()
        {
            InitializeComponent();
            // Optionally load a default view on startup
            MainContent.Content = new CouponManagementWindow(); // Load CouponManagementWindow by default
        }

        private void CouponManagement_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CouponManagementWindow();
        }
    }
}
