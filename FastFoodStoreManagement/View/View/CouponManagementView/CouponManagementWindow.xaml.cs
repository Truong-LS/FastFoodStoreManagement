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
using Models;
using Services.Services;
using System.Collections.ObjectModel;

namespace View
{
    /// <summary>
    /// Interaction logic for CouponManagementWindow.xaml
    /// </summary>
    public partial class CouponManagementWindow : UserControl
    {
        private readonly DiscountService _discountService;
        public ObservableCollection<Discounts> Discounts { get; set; }

        public CouponManagementWindow()
        {
            InitializeComponent();
            _discountService = new DiscountService();
            Discounts = new ObservableCollection<Discounts>();
            DataContext = this;
            LoadDiscounts();
        }

        private void LoadDiscounts()
        {
            Discounts.Clear();
            var discounts = _discountService.GetAllDiscounts();
            foreach (var discount in discounts)
            {
                Discounts.Add(discount);
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new AddCouponWindow { Owner = Window.GetWindow(this) };
            if (dlg.ShowDialog() == true)
            {
                LoadDiscounts();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var selectedDiscount = (sender as Button).CommandParameter as Discounts;
            if (selectedDiscount != null)
            {
                var dlg = new UpdateCouponWindow(selectedDiscount) { Owner = Window.GetWindow(this) };
                if (dlg.ShowDialog() == true)
                {
                    LoadDiscounts();
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedDiscount = (sender as Button).CommandParameter as Discounts;
            if (selectedDiscount != null)
            {
                MessageBoxResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa coupon {selectedDiscount.Code} không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    _discountService.DeleteDiscount(selectedDiscount.DiscountId);
                    LoadDiscounts();
                }
            }
        }
    }
}
