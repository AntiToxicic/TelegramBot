namespace TelegramBot.ApplicationCore.Entities;

public class User : EntityBase
{
    public User(long id, string name) : base(id)
    {
        Name = name;
    }
    
    public string Name { get; set; }
}