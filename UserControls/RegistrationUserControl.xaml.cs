using System.Windows;
using System.Windows.Controls;

using userAppl;
using userAppl.Login;
using userAppl.Registration;

namespace userAppl.UserControls
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class RegistrationUserControl : UserControl
    {
        public RegistrationUserControl()
        {
            InitializeComponent();
            DataContext = new RegistrationViewModel();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginView loginWindow = new LoginView();
            loginWindow.Show();
            Window.GetWindow(this)?.Close();
            //this.Close();
        }
    }
}