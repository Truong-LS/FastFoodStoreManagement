using Models;
using Services.Services;
using System;
using System.Windows;

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
            CboLoai.SelectedIndex = CurrentDiscount.Type ?? 0;
            TxtGiaTri.Text = CurrentDiscount.Value.ToString();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CurrentDiscount.Code = TxtMaCoupon.Text;
                CurrentDiscount.StartDate = DpNgayTao.SelectedDate;
                CurrentDiscount.EndDate = DpNgayHetHan.SelectedDate;
                CurrentDiscount.Type = CboLoai.SelectedIndex;
                CurrentDiscount.Value = double.TryParse(TxtGiaTri.Text, out double value) ? value : 0.0;
                
                _discountService.UpdateDiscount(CurrentDiscount);
                MessageBox.Show("Discount updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating discount: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
} 