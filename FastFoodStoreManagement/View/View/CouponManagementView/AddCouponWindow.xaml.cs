using Models;
using Services.Services;
using System;
using System.Windows;

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
                var newDiscount = new Discounts
                {
                    Code = TxtMaCoupon.Text,
                    StartDate = DpNgayTao.SelectedDate,
                    EndDate = DpNgayHetHan.SelectedDate,
                    Type = CboLoai.SelectedIndex,
                    Value = double.TryParse(TxtGiaTri.Text, out double value) ? value : 0.0,
                    IsActive = true // Default to active for new discounts
                };
                _discountService.AddDiscount(newDiscount);
                MessageBox.Show("Discount created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating discount: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
} 