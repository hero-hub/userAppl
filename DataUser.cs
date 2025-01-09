using System.ComponentModel;
using System.Diagnostics;

public class DataUser : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private string userName;

    private string password;

    private string email;

    public string UserName
    {
        get => userName;
        set
        {
            userName = value;
            OnPropertyChanged(nameof(UserName));
        }
    }
    public string Password
    {
        get => password;
        set {
            password = value;
            OnPropertyChanged(nameof(Password));
        } 
    }
    public string Email
    {
        get => email;
        set {
            email = value;
            OnPropertyChanged(nameof(Email));
        }
    }

    public DataUser(string username, string password, string email)
    {
        UserName = username;
        Password = password;
        Email = email;
    }
    public DataUser()
    {
    
    }

}

public class DataUserWithRepeatPass : DataUser
{
    private string repeatPass;

    public string RepeatPass
    {
        get => repeatPass;
        set
        {
            repeatPass = value;
            OnPropertyChanged(nameof(RepeatPass));
        }
    }

    public DataUserWithRepeatPass() : base()
    {
    }

    public DataUserWithRepeatPass(string username, string password, string email, string repeatPass)
        : base()
    {
        UserName = username;
        Password = password;
        Email = email;
        RepeatPass = repeatPass;
    }
}
