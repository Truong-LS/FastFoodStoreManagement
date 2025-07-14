using System.Windows;
using Models;
using Repositories.Repositories;
using Services.Interfaces;
using Services.Services;
using View.ManagerView;

namespace View
{
    public partial class Login : Window
    {
        private readonly IUserService _userService;

        public Login()
        {
            InitializeComponent();
            var context = new FastFoodDbContext();
            var userRepo = new UserRepos(context);
            _userService = new UserService(userRepo);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password;

            var user = _userService.Login(username, password);

            if (user != null && user.IsActive == true)
            {
                SessionService.SetUser(user);  

                switch (user.Role.RoleName?.ToLowerInvariant())
                {
                    case "admin":
                        new AccountManagement().Show();
                        break;

                    case "staff":
                        new StaffMainWindow().Show();
                        break;

                    case "manager":
                        MessageBox.Show("Redirect logic for managers not implemented.");
                        break;

                    default:
                        MessageBox.Show("Unrecognized role.");
                        break;
                }

                this.Close();  
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu.");
            }
        }
    }
}
