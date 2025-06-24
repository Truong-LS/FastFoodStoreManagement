using System.Windows;
using System.Windows.Controls;

namespace View
{
    /// <summary>
    /// Interaction logic for ShiffManagementWindow.xaml
    /// </summary>
    public partial class ShiffManagementWindow : UserControl
    {
        public ShiffManagementWindow()
        {
            InitializeComponent();
            
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new CreateShiffWindow { Owner = Window.GetWindow(this) };
            if (dlg.ShowDialog() == true)
            {
                // reload data nếu cần
            }
        }

        //private void BtnShift_Click(object sender, RoutedEventArgs e)
        //{
        //    MainContent.Content = new ShiffManagementWindow();
        //}

        //private void BtnCoupon_Click(object sender, RoutedEventArgs e)
        //{
        //    MainContent.Content = new CouponManagementWindow();
        //}
    }
}
