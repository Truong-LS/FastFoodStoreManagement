using Models;
using Services.Services;
using System;
using System.Windows;
using System.Linq; // Added for .Cast()
using System.Windows.Controls; // Added for ComboBoxItem

namespace View
{
    /// <summary>
    /// Interaction logic for UpdateCouponWindow.xaml
    /// </summary>
    public partial class UpdateCouponWindow : Window
    {
        private readonly DiscountService _discountService;
        public Discounts CurrentDiscount { get; set; }

        public UpdateCouponWindow(Discounts discount)
        {
            InitializeComponent();
            _discountService = new DiscountService();
            CurrentDiscount = discount;
            
            // Populate fields for editing
            TxtMaCoupon.Text = CurrentDiscount.Code;
            DpNgayTao.SelectedDate = CurrentDiscount.StartDate;
            DpNgayHetHan.SelectedDate = CurrentDiscount.EndDate;
            
            // Set selected item for ComboBox based on CurrentDiscount.Type int
            if (CurrentDiscount.Type == 1)
            {
                CboLoai.SelectedItem = CboLoai.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == "%" || item.Content.ToString() == "%");
            }
            else if (CurrentDiscount.Type == 2)
            {
                CboLoai.SelectedItem = CboLoai.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == "đồng");
            }
            else
            {
                CboLoai.SelectedIndex = 0;
            }

            TxtGiaTri.Text = CurrentDiscount.Value.ToString();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
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

                CurrentDiscount.Code = TxtMaCoupon.Text;
                CurrentDiscount.StartDate = DpNgayTao.SelectedDate;
                CurrentDiscount.EndDate = DpNgayHetHan.SelectedDate;
                CurrentDiscount.Type = typeValue;
                CurrentDiscount.Value = value;
                
                _discountService.UpdateDiscount(CurrentDiscount);
                MessageBox.Show("Cập nhật coupon thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                this.Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"Lỗi cập nhật coupon: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
} 