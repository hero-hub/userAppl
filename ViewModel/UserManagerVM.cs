using System.Windows.Input;

namespace App
{
    public class UserManagerVM : BaseViewModel
    {
        private readonly UserManager _userManager = new UserManager();

        public UserManagerVM()
        {
            RegisterCommand = new RelayCommand(Register, CanRegister);
            LoginCommand = new RelayCommand(Login, CanLogin);
        }

        // Свойства для данных
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public string ErrorMessage { get; set; }

        // Команды
        public ICommand RegisterCommand { get; }
        public ICommand LoginCommand { get; }

        // Методы для регистрации
        private void Register(object parameter)
        {
            AdvencedUser user = new AdvencedUser
            {
                UserName = UserName,
                Email = Email,
                Password = Password,
                RepeatPass = RepeatPassword
            };

            int result = _userManager.Register(user);

            switch (result)
            {
                case 0:
                    ErrorMessage = "Пожалуйста, заполните все поля.";
                    break;
                case 1:
                    ErrorMessage = "Пароли не совпадают.";
                    break;
                case 2:
                    ErrorMessage = "Пользователь уже зарегистрирован.";
                    break;
                case 3:
                    ErrorMessage = "Успешная регистрация.";
                    _userManager.SaveUsers();
                    break;
            }
            OnPropertyChanged(nameof(ErrorMessage));
        }

        private bool CanRegister(object parameter)
        {
            return !string.IsNullOrWhiteSpace(UserName) &&
                   !string.IsNullOrWhiteSpace(Email) &&
                   !string.IsNullOrWhiteSpace(Password) &&
                   !string.IsNullOrWhiteSpace(RepeatPassword);
        }

        // Методы для входа
        private void Login(object parameter)
        {
            int result = _userManager.Signin(UserName, Password);

            switch (result)
            {
                case 0:
                    ErrorMessage = "Заполните все поля.";
                    break;
                case 1:
                    ErrorMessage = "Добро пожаловать!";
                    break;
                case 2:
                    ErrorMessage = "Неверный пароль.";
                    break;
                case 3:
                    ErrorMessage = "Пользователь не найден.";
                    break;
            }
            OnPropertyChanged(nameof(ErrorMessage));
        }

        private bool CanLogin(object parameter)
        {
            return !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password);
        }
    }
}
