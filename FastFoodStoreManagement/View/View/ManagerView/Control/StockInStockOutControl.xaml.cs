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

namespace View.ManagerView.Control
{
    /// <summary>
    /// Interaction logic for StockInStockOutControl.xaml
    /// </summary>
    public partial class StockInStockOutControl : UserControl
    {
        public StockInStockOutControl()
        {
            InitializeComponent();
        }

        private void OpenPopup_Click(object sender, RoutedEventArgs e)
        {
            CreatePopup.IsOpen = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            CreatePopup.IsOpen = false;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Thêm xử lý lưu dữ liệu ở đây...
            MessageBox.Show("Đã lưu sản phẩm");

            // Tắt popup sau khi lưu
            CreatePopup.IsOpen = false;
        }
    }
}
