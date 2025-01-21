using System.Windows.Input;

namespace App
{
    public class RegistrationWindowViewModel : BaseViewModel
    {
        private readonly UserManager _userManager;


        // Properties
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPass { get; set; }

        public string ErrorUserName { get; set; }
        public string ErrorEmail { get; set; }
        public string ErrorPassword { get; set; }
        public string ErrorRepeatPass { get; set; }

        public ICommand RegisterCommand { get; }
        public ICommand NavigateToLoginCommand { get; }

        private void Register(object parameter)
        {
            AdvencedUser user = new AdvencedUser
            {
                UserName = UserName,
                Email = Email,
                Password = Password,
                RepeatPass = RepeatPass
            };

            UserManager result = _userManager.Register(user);

            ErrorUserName = result == 0 ? "Заполните поле" : string.Empty;
            ErrorEmail = result == 2 ? "Email уже зарегистрирован" : string.Empty;
            ErrorPassword = result == 1 ? "Пароли не совпадают" : string.Empty;
            OnPropertyChanged(nameof(ErrorUserName));
            OnPropertyChanged(nameof(ErrorEmail));
            OnPropertyChanged(nameof(ErrorPassword));
        }

        private void NavigateToLogin(object parameter)
        {
            LoginWindow loginWindow = new LoginWindow();
            Application.Current.MainWindow = loginWindow;
            loginWindow.Show();
        }
        public RegistrationWindowViewModel()
        {
            _userManager = new UserManager();
            RegisterCommand = new RelayCommand(Register);
            NavigateToLoginCommand = new RelayCommand(NavigateToLogin);
        }
    }
}
