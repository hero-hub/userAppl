using System;
using System.Windows;

namespace App
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            DataContext = new RegistrationViewModel();
        }
        //private void LoginButton_Click(object sender, RoutedEventArgs e)
        //{
        //    LoginWindow loginWindow = new LoginWindow();
        //    loginWindow.Show();
        //    this.Close();
        //}
    }
}
