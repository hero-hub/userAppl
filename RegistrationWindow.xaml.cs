﻿using System.Windows;

namespace App
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            this.DataContext = new DataUserWithRepeatPass();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            DataUserWithRepeatPass newUser = (DataUserWithRepeatPass)this.DataContext;
            UserManager userManager = new UserManager();

            switch (userManager.Register(newUser))
            {
                case 0:
                    MessageBox.Show("Пожалуйста, заполните все поля");
                    return;
                case 1:
                    MessageBox.Show("Пароли не совпадают!");
                    return;
                case 2:
                    MessageBox.Show("Пользователь уже зарегистрирован");
                    return;
                case 3:
                    MessageBox.Show("Успешная регистрация");
                    userManager.SaveUsers();
                    return;
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
