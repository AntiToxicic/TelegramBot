using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.Infrastructure.DataBase.SQLite.Tables;

public class UserDBTable : User
{
   public UserDBTable(string name) : base(name) { }
    
    public List<PictureDBTable> Pictures { get; set; } = new();

}