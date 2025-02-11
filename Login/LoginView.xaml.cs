using System.Windows;
using userAppl.Registration;

namespace userAppl.Login
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }
        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationView regWindow = new RegistrationView();
            regWindow.Show();
            this.Close();
        }
    }
}