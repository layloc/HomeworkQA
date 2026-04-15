namespace TestHomework;

public class AccountData
{
    public string Password { get; set; }
    public string Username { get; set; }

    public AccountData(string username, string password)
    {
        Password = password;
        Username = username;
    }
}