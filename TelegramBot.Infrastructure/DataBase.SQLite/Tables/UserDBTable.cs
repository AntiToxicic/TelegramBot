using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.Infrastructure.DataBase.Tables;

public class UserDBTable : User
{
    public UserDBTable(string name) : base(name) { }
    
    public  Picture picture { get; set; }
}