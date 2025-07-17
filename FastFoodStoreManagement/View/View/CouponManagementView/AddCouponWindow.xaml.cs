using Models;
using Services.Services;
using System;
using System.Windows;
using System.Windows.Controls; // Added for ComboBoxItem

namespace View
{
    /// <summary>
    /// Interaction logic for AddCouponWindow.xaml
    /// </summary>
    public partial class AddCouponWindow : Window
    {
        private readonly DiscountService _discountService;

        public AddCouponWindow()
        {
            InitializeComponent();
            _discountService = new DiscountService();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Input validation
                if (string.IsNullOrWhiteSpace(TxtMaCoupon.Text))
                {
                    MessageBox.Show("Mã Coupon không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (DpNgayTao.SelectedDate == null)
                {
                    MessageBox.Show("Ngày tạo không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (DpNgayHetHan.SelectedDate == null)
                {
                    MessageBox.Show("Ngày hết hạn không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (DpNgayHetHan.SelectedDate < DpNgayTao.SelectedDate)
                {
                    MessageBox.Show("Ngày hết hạn phải sau ngày tạo.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!double.TryParse(TxtGiaTri.Text, out double value) || value <= 0)
                {
                    MessageBox.Show("Giá trị phải là số dương.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string selectedType = (CboLoai.SelectedItem as ComboBoxItem)?.Content.ToString();
                if (string.IsNullOrEmpty(selectedType))
                {
                    MessageBox.Show("Loại coupon không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (selectedType == "%" && (value < 1 || value > 100))
                {
                    MessageBox.Show("Giá trị phần trăm phải từ 1 đến 100.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                int typeValue = 0;
                if (selectedType == "%")
                {
                    typeValue = 1;
                }
                else if (selectedType == "đồng")
                {
                    typeValue = 2;
                }

                var newDiscount = new Discounts
                {
                    Code = TxtMaCoupon.Text,
                    StartDate = DpNgayTao.SelectedDate,
                    EndDate = DpNgayHetHan.SelectedDate,
                    Type = typeValue,
                    Value = value,
                    IsActive = true // Default to active for new discounts
                };
                _discountService.AddDiscount(newDiscount);
                MessageBox.Show("Tạo coupon thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                this.Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"Lỗi tạo coupon: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
} 