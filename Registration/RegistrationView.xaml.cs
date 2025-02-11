using System;
using System.Windows;
using userAppl.Registration;

namespace userAppl.Registration
{
    public partial class RegistrationView : Window
    {
        public RegistrationView()
        {
            InitializeComponent();
            DataContext = new RegistrationViewModel();
        }
        //private void LoginButton_Click(object sender, RoutedEventArgs e)
        //{
        //    LoginView loginWindow = new LoginView();
        //    loginWindow.Show();
        //    this.Close();
        //}
    }
}