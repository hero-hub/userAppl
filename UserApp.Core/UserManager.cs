﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using UserApp.Domain.Models;

namespace UserApp.Core
{
    public class UserManager
    {
        private List<DataUserModel> _users = new List<DataUserModel>(); // Лист пользователей
        private readonly HashingService _hashingService = new HashingService(); // Объект класса HashingService
        private string filePath = "users.txt";

        public void SaveUsers()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (DataUserModel user in _users)
                    writer.WriteLine(user.UserName + "," + user.Password + "," + user.Email);
            }
        }

        public bool LoadUsers()
        {
            if (!File.Exists(filePath)) return false;

            _users.Clear();
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length != 3)
                    return false;

                DataUserModel user = new DataUserModel(parts[0], parts[1], parts[2]);
                _users.Add(user);
            }

            return true;
        }

        // Регистрация
        public int Register(AdvencedUserModel user)
        {
            if (string.IsNullOrWhiteSpace(user.UserName) ||
                string.IsNullOrWhiteSpace(user.Email) ||
                string.IsNullOrWhiteSpace(user.Password) ||
                string.IsNullOrWhiteSpace(user.RepeatPass))
                return 0; // Пустые поля

            LoadUsers();

            if (user.Password != user.RepeatPass)
                return 1; // Пароли не совпадают

            if (_users.Exists(u => u.UserName == user.UserName || u.Email == user.Email))
                return 2; // Пользователь уже существует

            // Хеширование пароля
            var hashUser = user;
            hashUser.Password = _hashingService.HashPassword(hashUser.Password);
            user.Password = hashUser.Password;

            _users.Add(user);
            return 3; // Успешная регистрация
        }

        // Авторизация
        public int Signin(string login, string pass)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(pass))
                return 0; // Пустые поля

            LoadUsers();

            var user = _users.FirstOrDefault(u => u.UserName == login || u.Email == login);

            if (user != null)
            {
                if (_hashingService.VerifyPassword(pass, user.Password))
                    return 1; // Успешный вход
                else
                    return 2; // Неверный пароль
            }

            return 3; // Пользователь не найден
        }
    }

}
