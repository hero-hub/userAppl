using System;
using System.Windows;
using System.Windows.Input;

namespace App
{
    public class RegistrationVM : BaseViewModel
    {
        private readonly UserManager _userManager;


        // Properties
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPass { get; set; }

        public string ErrorMessage {  get; set; }

        public ICommand RegisterCommand { get; }

        private void Register(object parameter)
        {
            AdvencedUserModel user = new AdvencedUserModel
            {
                UserName = UserName,
                Email = Email,
                Password = Password,
                RepeatPass = RepeatPass
            };

            int result = _userManager.Register(user);
            MessageBox.Show(result == 0 ? "" : ""); // временный вывод

            ErrorMessage = result == 3 ? "Успешная регистрация" : string.Empty;
            ErrorMessage = result == 2 ? "Email уже зарегистрирован" : string.Empty;
            ErrorMessage = result == 1 ? "Пароли не совпадают" : string.Empty;
            ErrorMessage = result == 0 ? "Пустые поля" : string.Empty;

            OnPropertyChanged(nameof(ErrorMessage));
        }

        public RegistrationVM()
        {
            _userManager = new UserManager();
            RegisterCommand = new RelayCommand(Register);
        }
    }
}
