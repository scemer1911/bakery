using Bakery;
using System;
using System.Windows;

namespace BakeryApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
             InitializeComponent();
            MainFrame.Navigate(new AdminUsersPage());
        }
    }
}