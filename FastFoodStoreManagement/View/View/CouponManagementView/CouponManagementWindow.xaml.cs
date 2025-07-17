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
        public ObservableCollection<DiscountDisplayItem> Discounts { get; set; }

        public CouponManagementWindow()
        {
            InitializeComponent();
            _discountService = new DiscountService();
            Discounts = new ObservableCollection<DiscountDisplayItem>();
            DataContext = this;
            LoadDiscounts();
        }

        private void LoadDiscounts()
        {
            Discounts.Clear();
            var discounts = _discountService.GetAllDiscounts();
            foreach (var discount in discounts)
            {
                Discounts.Add(new DiscountDisplayItem(discount));
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
            var selectedDiscountDisplayItem = (sender as Button).CommandParameter as DiscountDisplayItem;
            if (selectedDiscountDisplayItem != null)
            {
                var originalDiscount = _discountService.GetDiscountById(selectedDiscountDisplayItem.DiscountId);
                if (originalDiscount != null)
                {
                    var dlg = new UpdateCouponWindow(originalDiscount) { Owner = Window.GetWindow(this) };
                    if (dlg.ShowDialog() == true)
                    {
                        LoadDiscounts();
                    }
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedDiscountDisplayItem = (sender as Button).CommandParameter as DiscountDisplayItem;
            if (selectedDiscountDisplayItem != null)
            {
                MessageBoxResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa coupon {selectedDiscountDisplayItem.Code} không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    _discountService.DeleteDiscount(selectedDiscountDisplayItem.DiscountId);
                    LoadDiscounts();
                }
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = TxtSearchCode.Text.Trim();
            Discounts.Clear();
            var searchResults = string.IsNullOrEmpty(searchTerm) ? _discountService.GetAllDiscounts() : _discountService.SearchDiscountsByCode(searchTerm);
            foreach (var discount in searchResults)
            {
                Discounts.Add(new DiscountDisplayItem(discount));
            }
        }

        private void ResetSearch_Click(object sender, RoutedEventArgs e)
        {
            TxtSearchCode.Text = string.Empty;
            LoadDiscounts();
        }

        private void TxtSearchCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Optional: You can implement live search here if desired, or keep it to manual button click.
            // For now, it will only trigger on button click to avoid excessive database calls.
        }
    }

    public class DiscountDisplayItem : Models.Discounts
    {
        public string DisplayType
        {
            get
            {
                if (Type == 1)
                {
                    return "%";
                }
                else if (Type == 2)
                {
                    return "đồng";
                }
                return "";
            }
        }

        public DiscountDisplayItem(Models.Discounts discount)
        {
            this.DiscountId = discount.DiscountId;
            this.Code = discount.Code;
            this.StartDate = discount.StartDate;
            this.EndDate = discount.EndDate;
            this.Type = discount.Type;
            this.Value = discount.Value;
            this.IsActive = discount.IsActive;
            this.Orders = discount.Orders;
        }
    }
}
