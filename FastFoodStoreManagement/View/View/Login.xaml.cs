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
        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            FastFoodDbContext dbContext = new FastFoodDbContext();
            Users user = dbContext.Users.FirstOrDefault(u => u.UserName == txtUsername.Text && u.Password == txtPassword.Password);

            if(user !=null)
            {
                if (user.IsActive == true && user.RoleId == 3)
                {
                    Application.Current.Properties["CurrentUserId"] = user.UserId;
                    // Login successful, open the main window
                    MessageBox.Show("Welcome "+user.FullName+" Role: Administrator", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
                    StaffMainWindow staffMainWindow = new StaffMainWindow();
                    staffMainWindow.Show();
                    this.Close(); // Close the login window
                }else if(user.IsActive == true && user.RoleId == 2)
                {
                    // Login successful, open the main window
                    MessageBox.Show("Welcome " + user.FullName + " Role: Manager", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
                    StaffMainWindow staffMainWindow = new StaffMainWindow();
                    staffMainWindow.Show();
                    this.Close(); // Close the login window
                }
               
                else
                {
                    MessageBox.Show("Your account is inactive. Please contact the administrator.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}