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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace View.ManagerView.Control
{
    /// <summary>
    /// Interaction logic for StockManagementControl.xaml
    /// </summary>
    public partial class StockManagementControl : UserControl
    {
        private StockService _stockService = new StockService();
        public StockManagementControl()
        {
            InitializeComponent();
            LoadMaterials();
        }

        public void LoadMaterials()
        {
            try
            {
                var materials = _stockService.GetAllMaterials();
                if (materials != null && materials.Count > 0)
                {
                    MaterialsDataGrid.ItemsSource = materials;
                }
                else
                {
                    MessageBox.Show("No materials found.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading materials: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
