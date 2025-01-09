using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Shapes;
using System.Windows;
using UserApp;
using System.Linq;

public class UserManager
{
    private List<DataUser> _users = new List<DataUser>();// Лист пользователей

    private readonly HashingService _hashingService = new HashingService(); // Объект класса HashingServise
    private string FilePath = "users.txt";
    
    public void SaveUsers()
    {
        using (StreamWriter writer = new StreamWriter(FilePath))
        {
            foreach (DataUser user in _users)
                writer.WriteLine(user.UserName + "," + user.Password + "," + user.Email);
        }
    }

    public bool LoadUsers()
    {
        try
        {
            if (!File.Exists(FilePath)) return false;

            _users.Clear();
            string[] lines = File.ReadAllLines(FilePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length != 3)
                    return false;

                DataUser user = new DataUser(parts[0], parts[1], parts[2]);

                _users.Add(user);
            }

            return true;
        }
        catch
        {
            return false;
        }
    }

    // Регистрация
    public int Register(DataUserWithRepeatPass user)
    {
        LoadUsers();

        // Пустые поля
        if (String.IsNullOrWhiteSpace(user.UserName) ||
            String.IsNullOrWhiteSpace(user.Email) ||
            String.IsNullOrWhiteSpace(user.Password) ||
            String.IsNullOrWhiteSpace(user.RepeatPass)) 
            return 0;

        // Сравнение паролей
        if (user.Password != user.RepeatPass) 
            return 1;

        // Поиск пользователя
        if (_users.Exists(u => (u.UserName == user.UserName || u.Email == user.Email)))
            return 2;

        user.Password = _hashingService.HashPassword(user.Password);
        _users.Add(user);

        return 3;
    }

    // Авторизация
    public int Login(string login, string pass) 
    {
        LoadUsers();

        if (String.IsNullOrWhiteSpace(login) || String.IsNullOrWhiteSpace(pass)) 
            return 0; // Пустые поля

        DataUser user = _users.FirstOrDefault(u => u.UserName == login || u.Email == login);

        if (user != null)
        {
            if (_hashingService.VerifyPassword(pass, user.Password))
                return 1; // Успешный вход
            else
                return 2; // Неправильный пароль
        }
        return 3; // Пользователь не найден


        //string[] lines = File.ReadAllLines(FilePath);
        //foreach (string line in lines)
        //{
        //    string[] parts = line.Split(',');

        //    if (parts.Length != 3)
        //        continue;

        //    string storedLogin = parts[0];
        //    string storedEmail = parts[1];
        //    string storedHashedPass = parts[2];

        //    if (login == storedLogin || login == storedEmail)
        //    {
        //        if (_hashingService.VerifyPassword(pass, storedHashedPass)) return 1;

        //        else return 2;
        //    }
        //}
    }
}
