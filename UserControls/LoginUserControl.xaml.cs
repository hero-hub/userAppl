using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using userAppl.Login;
using userAppl.Registration;

namespace userAppl.UserControls
{
    /// <summary>
    /// Логика взаимодействия для LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        public LoginUserControl()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }
        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationView regWindow = new RegistrationView();
            regWindow.Show();
            Window.GetWindow(this)?.Close();
        }
    }

}