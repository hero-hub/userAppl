using System.Windows;
using userAppl.Login;
using userAppl.Registration;


namespace userAppl
{
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        public void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            var registrationWindow = new RegistrationView();
            registrationWindow.Show();
            this.Close();
        }
        public void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginView();
            loginWindow.Show();
            this.Close();
        }
    }
}