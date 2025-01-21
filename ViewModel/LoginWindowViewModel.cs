using System.Windows;
using System.Windows.Input;

namespace App
{
    public class LoginWindowViewModel : BaseViewModel
    {
        private readonly UserManager _userManager;


        public string Login { get; set; }
        public string Password { get; set; }
        public string ErrorLogin { get; set; }
        public string ErrorPassword { get; set; }

        public ICommand LoginCommand { get; }
        public ICommand NavigateToRegistrationCommand { get; }

        private void Log(object parameter)
        {
            UserManager result = _userManager.Signin(Login, Password);

            ErrorLogin = result == 3 ? "Пользователь не найден" : string.Empty;
            ErrorPassword = result == 2 ? "Неверный пароль" : string.Empty;
            OnPropertyChanged(nameof(ErrorLogin));
            OnPropertyChanged(nameof(ErrorPassword));

            if (result == 1)
            {
                MessageBox.Show("Добро пожаловать!");
            }
        }

        private void NavigateToRegistration(object parameter)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            Application.Current.MainWindow = registrationWindow;
            registrationWindow.Show();
        }
        public LoginWindowViewModel()
        {
            _userManager = new UserManager();
            LoginCommand = new RelayCommand(Log);
            NavigateToRegistrationCommand = new RelayCommand(NavigateToRegistration);
        }
    }
}
