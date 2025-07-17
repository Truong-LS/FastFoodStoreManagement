using Models;
using Services.Services;
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
        private StockService _stockService = new StockService();
        public StockInStockOutControl()
        {
            InitializeComponent();
            LoadLog();
            LoadComboBox();
        }

        public void LoadLog()
        {
            try
            {
                var logs = _stockService.GetAllLog();

                DateTime? fromDate = FromDatePicker.SelectedDate;
                DateTime? toDate = ToDatePicker.SelectedDate;


                if (fromDate.HasValue)
                    logs = logs.Where(l => l.CreatedAt >= fromDate.Value).ToList();

                if (toDate.HasValue)
                    logs = logs.Where(l => l.CreatedAt <= toDate.Value).ToList();

                if (logs != null && logs.Count > 0)
                {
                    LogDataGrid.ItemsSource = logs;
                }
                else
                {
                    MessageBox.Show("No logs found.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading logs: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void LoadComboBox()
        {
            // Load materials into the MaterialComboBox
            var material = _stockService.GetAllMaterials();
            if (material == null || material.Count == 0)
            {
                MessageBox.Show("No materials found!");
            }
            else
            {
                foreach (var m in material)
                {
                    Console.WriteLine($"{m.MaterialId} - {m.Name}");
                }
            }
            MaterialComboBox.ItemsSource = material;

            // Load suppliers into the SupplierComboBox
            var suppliers = _stockService.GetAllSuppliers();
            SupplierComboBox.ItemsSource = suppliers;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadLog();
        }

        private void ClearDateFilters_Click(object sender, RoutedEventArgs e)
        {
            FromDatePicker.SelectedDate = null;
            ToDatePicker.SelectedDate = null;

            LoadLog();
        }


        // Popup control for creating new stock in/out records
        private void OpenPopup_Click(object sender, RoutedEventArgs e)
        {
            CreatePopup.IsOpen = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            CreatePopup.IsOpen = false;
            MaterialComboBox.SelectedIndex = -1;
            SupplierComboBox.SelectedIndex = -1;
            ChangeQtyTextBox.Clear();
            UnitTextBox.SelectedIndex = -1;
            NoteTextBox.Clear();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MaterialComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn nguyên liệu", "Warning");
                    return;
                }else if(LogTypeComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn loại nhập xuất", "Warning");
                    return;
                }else if (UnitTextBox.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn đơn vị", "Warning");
                    return;
                }

                var selectedLogType = LogTypeComboBox.SelectedItem as ComboBoxItem;
                string logType = selectedLogType?.Content?.ToString();

                
                int? supplierId = null;
                if (logType != "StockOut")
                {
                    if (SupplierComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("Vui lòng chọn nhà cung cấp", "Warning");
                        return;
                    }

                    supplierId = (int?)SupplierComboBox.SelectedValue;
                }

                if (!int.TryParse(ChangeQtyTextBox.Text, out int qty) || qty <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số lượng hợp lệ", "Warning");
                    return;
                }

                if (!Application.Current.Properties.Contains("CurrentUserId"))
                {
                    MessageBox.Show("Bạn chưa đăng nhập hoặc phiên làm việc đã hết hạn.", "Warning");
                    return;
                }
                int currentUserId = (int)Application.Current.Properties["CurrentUserId"];

                var MaterialID =    (int)MaterialComboBox.SelectedValue;
                var createdAt = DateTime.Now;

                qty = int.Parse(ChangeQtyTextBox.Text);
                int changeQty = (logType == "StockOut") ? -qty : qty;
                var log = new InventoryLogs
                {
                    MaterialId = (int)MaterialComboBox.SelectedValue,
                    SupplierId = supplierId,
                    ChangeQty = changeQty,
                    Unit = (UnitTextBox.SelectedItem as ComboBoxItem)?.Content?.ToString(),
                    Note = NoteTextBox.Text,
                    CreatedAt = DateTime.Now,
                    LogType = logType,
                    UserId = currentUserId
                };

                _stockService.AddStockLog(log);

                MaterialComboBox.SelectedIndex = -1;
                SupplierComboBox.SelectedIndex = -1;
                ChangeQtyTextBox.Clear();
                UnitTextBox.SelectedIndex = -1;
                NoteTextBox.Clear();

                CreatePopup.IsOpen = false;
                LoadLog();

                MessageBox.Show("Stock log created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error while creating stock log: {ex.Message}","Error");
            }
        }

        private void LogTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = LogTypeComboBox.SelectedItem as ComboBoxItem;
            if (selectedItem != null)
            {
                string selectedType = selectedItem.Content.ToString();
                if (selectedType == "StockOut")
                {
                    SupplierComboBox.IsEnabled = false;
                }
                else
                {
                    SupplierComboBox.IsEnabled = true;
                }
            }
        }
    }
}
