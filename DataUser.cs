using System.ComponentModel;

public class DataUser
{
    private string userName;

    private string password;

    private string email;

    public string UserName
    {
        get => userName;
        set => userName = value;
    }
    public string Password
    {
        get => password;
        set => password = value;
    }
    public string Email
    {
        get => email;
        set => email = value;
    }

    public DataUser(string username, string password, string email)
    {
        UserName = username;
        Password = password;
        Email = email;
    }

}

public class DataUserWithRepeatPass : DataUser
{
    private string repeatPass;

    public string RepeatPass
    {
        get => repeatPass;
        set => repeatPass = value;
    }

    public DataUserWithRepeatPass(string username, string password, string email, string repeatPass)
        : base(username, password, email)
    {
        RepeatPass = repeatPass;
    }
}
