using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Models;
using View.ManagerView;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly FastFoodDbContext _context = new();
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            var user = _context.Users
                .Where(u => u.UserName == username && u.Password == password && u.IsActive == true)
                .Select(u => new { u.UserId, u.FullName, u.Role.RoleName })
                .FirstOrDefault();

            if (user != null)
            {
                // Route based on role
                switch (user.RoleName?.ToLower())
                {
                    case "admin":
                        var adminWindow = new AccountManagement();
                        adminWindow.Show();
                        break;

                    case "staff":
                        var staffWindow = new StaffMainWindow();
                        staffWindow.Show();
                        break;

                    case "manager":
                        MessageBox.Show("Redirect logic for managers not implemented.");
                        break;

                    default:
                        MessageBox.Show("Unrecognized role.");
                        break;
                }

                this.Close(); // Close login window
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}