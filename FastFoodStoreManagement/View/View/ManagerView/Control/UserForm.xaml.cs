using System;
using System.Linq;
using System.Windows;
using Models;
using Repositories.Repositories;
using Services.Services;

namespace View.View.ManagerView.Control
{
    public partial class UserForm : Window
    {
        private readonly UserService _userService;
        private readonly Users? _editingUser;

        public UserForm(Users? user = null)
        {
            InitializeComponent();
            _userService = new UserService(new UserRepos(new FastFoodDbContext()));
            _editingUser = user;

            LoadRoles();

            if (_editingUser != null)
            {
                // Populate fields for edit mode
                txtFullName.Text = _editingUser.FullName;
                txtUsername.Text = _editingUser.UserName;
                txtPassword.Password = _editingUser.Password;
                cmbRole.SelectedItem = _editingUser.Role?.RoleName;
                chkIsActive.IsChecked = _editingUser.IsActive;
            }
        }

        private void LoadRoles()
        {
            using var db = new FastFoodDbContext();
            var roleNames = db.Roles.Select(r => r.RoleName).ToList();
            cmbRole.ItemsSource = roleNames;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var name = txtFullName.Text.Trim();
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Password;
            var roleName = cmbRole.SelectedItem?.ToString();
            var isActive = chkIsActive.IsChecked == true;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(roleName))
            {
                MessageBox.Show("Please fill all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var roleId = GetRoleIdByName(roleName);

            if (_editingUser != null)
            {
                // Update existing user
                _editingUser.FullName = name;
                _editingUser.UserName = username;
                _editingUser.Password = password;
                _editingUser.RoleId = roleId;
                _editingUser.IsActive = isActive;

                _userService.UpdateUser(_editingUser);
            }
            else
            {
                // Create new user
                var newUser = new Users
                {
                    FullName = name,
                    UserName = username,
                    Password = password,
                    RoleId = roleId,
                    IsActive = isActive
                };

                _userService.CreateUser(newUser);
            }

            this.DialogResult = true;
            this.Close();
        }

        private int GetRoleIdByName(string? roleName)
        {
            using var db = new FastFoodDbContext();
            var role = db.Roles.FirstOrDefault(r => r.RoleName == roleName);
            return role?.RoleId ?? 0;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
 