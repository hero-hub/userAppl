using System.Windows;

namespace App
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginWindowVM();
        }
        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow regWindow = new RegistrationWindow();
            regWindow.Show();
            this.Close();
        }
    }
}
