using Models;
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

namespace View.StaffView
{
    /// <summary>
    /// Interaction logic for MomoPaymentPage.xaml
    /// </summary>
    public partial class MomoPaymentPage : Page
    {
        private readonly ObservableCollection<Carts> _carts;
        private readonly decimal _totalAmount;
        private readonly Discounts _discounts;
        private readonly IOrdersService _ordersService;
        private readonly IOrderDetailsService _orderDetailsService;
        private readonly IDiscountsService _discountsService;
        private readonly IMaterialsService _materialsService;
        private readonly IPaymentsService _paymentsService;
        public MomoPaymentPage(ObservableCollection<Carts> carts, decimal totalAmount, Discounts discount)
        {
            InitializeComponent();
            _ordersService = new OrdersService();
            _orderDetailsService = new OrderDetailsService();
            _discountsService = new DiscountsService();
            _materialsService = new MaterialsService();
            _paymentsService = new PaymentsService();

            _carts = carts;
            _totalAmount = totalAmount;
            _discounts = discount;

            TotalAmountText.Text = $"Tổng số tiền: {_totalAmount:N0} ₫";
        }
        

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 1. Tạo Order mới
                var order = new Orders
                {
                    OrderTime = DateTime.Now,
                    TotalAmount = (double)_totalAmount,
                    Status = true,
                    UserId = 1
                };

                if (_discounts != null)
                {
                    order.DiscountId = _discounts.DiscountId;
                    _discountsService.UseDiscount(_discounts.Code);
                }

                int orderId = _ordersService.CreateOrder(order);

                var details = _carts.Select(c => new OrderDetails
                {
                    OrderId = orderId,
                    ItemId = c.item.ItemId,
                    Quantity = c.Quantity,
                    UnitPrice = c.item.Price
                }).ToList();

                foreach (var detail in details)
                {
                    var orderDetailResult = _orderDetailsService.CreateOrderDetail(detail);
                    if (orderDetailResult == null)
                    {
                        MessageBox.Show("Lỗi khi tạo chi tiết đơn hàng.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    var materialResult = _materialsService.UpdateMaterialsByOrderDetail(detail);
                    if (!materialResult)
                    {
                        MessageBox.Show("Không đủ nguyên liệu để thanh toán.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                var payment = new Payments
                {
                    Amount = (int)_totalAmount,
                    Method = "Cash",
                    PaidAt = DateTime.Now,
                    OrderId = orderId,
                };
                _paymentsService.CreatePayment(payment);
            }
            catch (Exception ex)
            {
                var errorMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Lỗi khi thanh toán: {errorMessage}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            finally
            {
                _carts.Clear();
                var orderPage = new OrderPage();
                NavigationService?.Navigate(orderPage);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null && NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
