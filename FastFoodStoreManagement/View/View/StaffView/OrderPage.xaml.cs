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
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public Dictionary<int, int> _productQuantities = new();
        public ObservableCollection<Carts> _cartItems { get; set; } = new();
        private readonly ICategoriesService _categoryService;
        private readonly IItemsService _itemsService;
        public OrderPage()
        {
            InitializeComponent();
            _categoryService = new CategoriesService();
            _itemsService = new ItemsService();
            Loaded += OrderWindow_Loaded;
        }
        // Khi cửa sổ được load, khởi tạo dữ liệu ban đầu (danh sách sản phẩm, danh mục,...)
        private void OrderWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategories();
            LoadProducts();
            CartListPanel.ItemsSource = _cartItems;
        }

        // Load danh mục sản phẩm vào ComboBox
        private void LoadCategories()
        {
            // TODO: Thêm danh sách danh mục vào CategoryComboBox
            var categoriesList = _categoryService.GetAllCategories();
            CategoryComboBox.ItemsSource = null;
            CategoryComboBox.ItemsSource = categoriesList;
        }

        // Load danh sách sản phẩm (theo danh mục hoặc tất cả)
        private void LoadProducts()
        {
            // TODO: Hiển thị sản phẩm trong ProductListPanel
            var itemsList = _itemsService.GetAllItems();
            ItemsListPanel.ItemsSource = null;
            ItemsListPanel.ItemsSource = itemsList;
        }

        // Tìm kiếm sản phẩm theo tên
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // TODO: Lọc danh sách sản phẩm theo từ khóa
            var keyword = SearchTextBox.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadProducts();
            }
            else
            {
                var filteredItems = _itemsService.SearchItems(keyword);
                ItemsListPanel.ItemsSource = null;
                ItemsListPanel.ItemsSource = filteredItems;
            }
        }

        // Khi thay đổi danh mục sản phẩm
        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: Lọc sản phẩm theo danh mục được chọn
            if (CategoryComboBox.SelectedItem is Categories selectedCategory)
            {
                var filteredItems = _itemsService.GetItemsByCategory(selectedCategory.CategoryId);
                ItemsListPanel.ItemsSource = null;
                ItemsListPanel.ItemsSource = filteredItems;
            }
        }

        // Thêm sản phẩm vào giỏ hàng
        private void AddToCart(object sender, RoutedEventArgs e)
        {
            // TODO: Lấy sản phẩm từ button Tag, thêm vào CartListPanel
            if (sender is Button btn && btn.DataContext is Items selectedItem)
            {
                int quantity = _productQuantities.ContainsKey(selectedItem.ItemId)
                                ? _productQuantities[selectedItem.ItemId]
                                : 1; // Nếu chưa bấm + thì mặc định là 1

                if (quantity <= 0)
                    return;

                var existing = _cartItems.FirstOrDefault(c => c.item.ItemId == selectedItem.ItemId);
                if (existing != null)
                {
                    existing.Quantity += quantity;
                }
                else
                {
                    _cartItems.Add(new Carts
                    {
                        item = selectedItem,
                        Quantity = quantity
                    });
                }

                _productQuantities[selectedItem.ItemId] = 0;
                RefreshItemsList();
            }
        }

        // Tăng số lượng sản phẩm trong giỏ
        private void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Tăng số lượng
            if (sender is Button button && button.DataContext is Items item)
            {
                if (!_productQuantities.ContainsKey(item.ItemId))
                    _productQuantities[item.ItemId] = 0;

                _productQuantities[item.ItemId]++;
                RefreshItemsList(); // cập nhật lại UI
            }
        }

        // Giảm số lượng sản phẩm trong giỏ
        private void DecreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Giảm số lượng (nếu > 1)
            if (sender is Button button && button.DataContext is Items item)
            {
                if (_productQuantities.ContainsKey(item.ItemId) && _productQuantities[item.ItemId] > 0)
                {
                    _productQuantities[item.ItemId]--;
                    RefreshItemsList();
                }
            }
        }

        // Xóa sản phẩm khỏi giỏ hàng
        private void RemoveFromCart_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Xóa item khỏi CartListPanel
            if (sender is Button button && button.DataContext is Carts cartItem)
            {
                _cartItems.Remove(cartItem);
            }
        }
        private void RefreshItemsList()
        {
            var currentItems = ItemsListPanel.ItemsSource?.Cast<Items>().ToList();
            ItemsListPanel.ItemsSource = null;
            ItemsListPanel.ItemsSource = currentItems;
        }

        // Khi người dùng nhấn "Proceed to Pay"
        private void ProceedToPay_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Mở trang hoặc popup thanh toán
            var processPaymentPage = new ProcessPaymentPage(_cartItems);
            NavigationService?.Navigate(processPaymentPage);
        }
    }
}
