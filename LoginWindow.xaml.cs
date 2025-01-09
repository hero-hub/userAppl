using System;
using System.Windows;
using System.Windows.Controls;
using UserApp;

namespace App
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            UserManager userManager = new UserManager();
           
            switch (userManager.Login(Login.Text, Password.Password))
            {
                case 0:
                    MessageBox.Show("Ошибка! Поля не заполнены");
                    return;
                case 1:
                    MessageBox.Show("Добро пожаловать!");
                    return;
                case 2:
                    MessageBox.Show("Неверный пароль");
                    return;
                case 3:
                    MessageBox.Show("Пользователь не найден");
                    return;
            }
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e) 
        {
            var registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }
    }
}
