using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.Infrastructure.DataBase.SQLite.Tables;

public class UserDBTable : User
{
   public UserDBTable(long id, string name) : base(id, name) { }
    
    public List<PictureDBTable> Pictures { get; set; } = new();

}