namespace TelegramBot.ApplicationCore.Entities;

public class User : EntityBase
{
    public User(string name)
    {
        this.name = name;
    }
    
    public string name { get; set; }
}