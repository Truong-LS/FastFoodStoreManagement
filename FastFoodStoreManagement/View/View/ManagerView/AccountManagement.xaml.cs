using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Models;
using Repositories.Repositories;
using Services.Services;
using View.View.ManagerView.Control; 

namespace View.ManagerView.Control
{
    public partial class AccountManagement : UserControl
    {
        private readonly UserService _userService;

        public AccountManagement()
        {
            InitializeComponent();
            _userService = new UserService(new UserRepos(new FastFoodDbContext()));
            LoadUserData();
        }

        private void LoadUserData()
        {
            var users = _userService.GetAllUsers();

            var displayList = users.Select(u => new
            {
                UserId = u.UserId,
                Name = u.FullName,
                Username = u.UserName,
                Password = u.Password,
                Role = u.Role.RoleName
            }).ToList();

            AccountDataGrid.ItemsSource = displayList;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var form = new UserForm();
            if (form.ShowDialog() == true)
            {
                LoadUserData();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (AccountDataGrid.SelectedItem is not null)
            {
                var selectedUserId = (int)AccountDataGrid.SelectedValue;
                var user = _userService.GetUserById(selectedUserId);
                if (user != null)
                {
                    var form = new UserForm(user);
                    if (form.ShowDialog() == true)
                    {
                        LoadUserData();
                    }
                }
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (AccountDataGrid.SelectedItem is not null)
            {
                var selectedUserId = (int)AccountDataGrid.SelectedValue;
                var result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _userService.DeleteUser(selectedUserId);
                    LoadUserData();
                }
            }
        }
    }
}
