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
using System.Windows.Shapes;

namespace View.Controls
{
    public partial class AccountManagement : UserControl
    {
        public AccountManagement()
        {
            InitializeComponent();
        }
        private void Logo_Click(object sender, MouseButtonEventArgs e)
        {
            // TODO: Implement your logo navigation logic
            MessageBox.Show("Logo clicked!");
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Handle edit logic here
            MessageBox.Show("Edit clicked!");
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Handle remove logic here
            MessageBox.Show("Remove clicked!");
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Handle create logic here
            MessageBox.Show("Create clicked!");
        }
    }
  

}
