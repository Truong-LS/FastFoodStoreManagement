﻿using System;
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

namespace View
{
    /// <summary>
    /// Interaction logic for CouponManagementWindow.xaml
    /// </summary>
    public partial class CouponManagementWindow : UserControl
    {
        public CouponManagementWindow()
        {
            InitializeComponent();
        }

        //private void BtnShift_Click(object sender, RoutedEventArgs e)
        //{
        //    MainContent.Content = new ShiffManagementWindow();
        //}

        //private void BtnCoupon_Click(object sender, RoutedEventArgs e)
        //{
        //    MainContent.Content = new CouponManagementWindow();
        //}

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new CreateCouponWindow { Owner = Window.GetWindow(this) };
            if (dlg.ShowDialog() == true)
            {
                // reload data nếu cần
            }
        }
    }
}
