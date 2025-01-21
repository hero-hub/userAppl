using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class AdvencedUser : DataUser
    {
        private string repeatPass;

        public string RepeatPass
        {
            get => repeatPass;
            set
            {
                repeatPass = value;
                OnPropertyChanged();
            }
        }

        public AdvencedUser() : base()
        {
        }

        public AdvencedUser(string username, string password, string email, string repeatPass)
            : base()
        {
            UserName = username;
            Password = password;
            Email = email;
            RepeatPass = repeatPass;
        }
    }

}
