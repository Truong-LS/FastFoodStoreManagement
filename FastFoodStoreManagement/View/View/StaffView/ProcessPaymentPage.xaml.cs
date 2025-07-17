using Models;
using Repositories.Interfaces;
using Services.Interfaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using View.Helper;
using View.StaffView;

namespace View.StaffView
{
    /// <summary>
    /// Interaction logic for ProcessPaymentPage.xaml
    /// </summary>
    public partial class ProcessPaymentPage : Page
    {
        private readonly IDiscountsService _discountsService;
        private ObservableCollection<Carts> _cartItems;
        private Discounts discounts = null;
        private double _discount = 0;
        private decimal _totalPayment = 0;
        public ProcessPaymentPage(ObservableCollection<Carts> cartItems)
        {
            InitializeComponent();
            _cartItems = cartItems;
            _discountsService = new DiscountsService(); // Khởi tạo kho giảm giá
            this.Loaded += ProcessPaymentPage_Loaded;
        }

        // Sự kiện khi trang được load
        private void ProcessPaymentPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Load dữ liệu hóa đơn, ngày giờ, nhân viên, v.v.
            // Gán danh sách sản phẩm vào ListView
            InvoiceItemsListView.ItemsSource = _cartItems.Select(c => new
            {
                TenSanPham = c.item.Name,
                SoLuong = c.Quantity,
                DonGia = $"{c.item.Price:N0} ₫",
                ThanhTien = $"{(c.item.Price * c.Quantity):N0} ₫"
            }).ToList();

            // Gán thông tin đơn hàng
            InvoiceCodeText.Text = $"Mã hóa đơn: HD-{DateTime.Now:yyyyMMddHHmmss}";
            InvoiceDateText.Text = $"Ngày: {DateTime.Now:dd/MM/yyyy HH:mm}";
            StaffNameText.Text = $"Nhân viên: {Environment.UserName}";

            UpdateTotalDisplay();
        }

        private void UpdateTotalDisplay()
        {
            var total = CalculateTotalAmount();
            TotalText.Text = $"Tổng tiền hàng: {total:N0} ₫";

            if (discounts == null)
            {
                _discount = 0;
                DiscountText.Text = "Giảm giá: 0 ₫";
            }
            else
            {
                _discount = (double)discounts.Value;

                if (discounts.Type == 2)
                {
                    DiscountText.Text = $"Giảm giá: {_discount:N0} ₫";
                }
                else if (discounts.Type == 1)
                {
                    DiscountText.Text = $"Giảm giá: {_discount:N0} %";
                }
                else
                {
                    DiscountText.Text = $"Giảm giá: không xác định";
                }
            }
            _totalPayment = total - CaculateDiscount();
            FinalTotalText.Text = $"Tổng thanh toán: {(_totalPayment):N0} ₫";
        }

        private decimal CalculateTotalAmount()
        {
            return _cartItems.Sum(c => (decimal)c.item.Price * (decimal)c.Quantity);
        }

        private decimal CaculateDiscount()
        {
            if (discounts == null)
                return 0;

            decimal amountReduced = 0;
            decimal total = CalculateTotalAmount();

            if (discounts.Type == 2)
            {
                amountReduced = (decimal)discounts.Value;
            }
            else
            {
                amountReduced = total * (decimal)discounts.Value / 100;
            }

            return amountReduced;
        }

        // Sự kiện khi nhấn nút "Kiểm tra" mã giảm giá
        private void CheckDiscount_Click(object sender, RoutedEventArgs e)
        {
            string discountCode = DiscountCodeTextBox.Text.Trim();
            if (string.IsNullOrEmpty(discountCode))
            {
                MessageBox.Show("Vui lòng nhập mã giảm giá.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = _discountsService.GetDiscountByCode(discountCode);
            if (result == null || result.EndDate < DateTime.Now)
            {
                MessageBox.Show("Mã giảm giá không hợp lệ hoặc đã hết hạn.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if ((bool)!result.IsActive)
            {
                MessageBox.Show("Mã giảm giá đã được sử dụng hoặc bị khóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            discounts = result;
            if (discounts.Type == 2)
            {
                DiscountResultText.Text = $"Giảm {discounts.Value}đ";
            }
            else
            {
                DiscountResultText.Text = $"Giảm {discounts.Value}%";
            }

        }

        // Sự kiện khi nhấn nút "Áp dụng" mã giảm giá
        private void ApplyDiscount_Click(object sender, RoutedEventArgs e)
        {
            if (discounts == null)
            {
                MessageBox.Show("Vui lòng kiểm tra mã giảm giá trước.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            UpdateTotalDisplay();

        }

        // Sự kiện khi nhấn nút "Thanh toán & xuất hóa đơn"
        private void ConfirmPayment_Click(object sender, RoutedEventArgs e)
        {
            // Thực hiện thanh toán và xuất hóa đơn
            
            if (CashRadio.IsChecked == true)
            {
                var paymentPage = new CashPaymentPage(_cartItems, _totalPayment, discounts);
                NavigationService?.Navigate(paymentPage);
            }
            else if (MoMoRadio.IsChecked == true)
            {
                var paymentPage = new MomoPaymentPage(_cartItems, _totalPayment, discounts);
                NavigationService?.Navigate(paymentPage);
            }
            else if (BankingRadio.IsChecked == true)
            {
                var paymentPage = new BankingPaymentPage(_cartItems, _totalPayment, discounts);
                NavigationService?.Navigate(paymentPage);
            }
            else if (CardRadio.IsChecked == true)
            {
                var paymentPage = new CardRadioPaymentPage(_cartItems, _totalPayment, discounts);
                NavigationService?.Navigate(paymentPage);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }

        // Sự kiện khi nhấn nút "Quay lại"
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Quay lại trang trước đó
            if (NavigationService != null && NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
