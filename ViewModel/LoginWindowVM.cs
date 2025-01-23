using System.Windows;
using System.Windows.Input;

namespace App
{
    public class LoginWindowVM : BaseViewModel
    {
        private readonly UserManager _userManager;

        public LoginWindowVM()
        {
            _userManager = new UserManager();
            LoginCommand = new RelayCommand(Log);
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public string ErrorMessage { get; set; }

        public ICommand LoginCommand { get; }
        public ICommand NavigateToRegistrationCommand { get; }

        private void Log(object parameter)
        {
            int result = _userManager.Signin(Login, Password);

            ErrorMessage = result == 3 ? "Пользователь не найден" : string.Empty;
            ErrorMessage = result == 2 ? "Неверный пароль" : string.Empty;
            ErrorMessage = result == 1 ? "Успешный код" : string.Empty;
            ErrorMessage = result == 0 ? "Пустые поля" : string.Empty;

            OnPropertyChanged(nameof(ErrorMessage));
        }
    }
}
