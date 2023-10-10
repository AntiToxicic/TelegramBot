using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.Infrastructure.DataBase.SQLite.Tables;

public class PictureDBTable : Picture
{
    public PictureDBTable(long id, long userId, string path, string caption = "Без подписи") : base(id, path, caption)
    {
        UserId = userId;
    }
    
    public long UserId { get; set; }
    public UserDBTable User { get; set; }
    
   // public List<UserDBTable> UserID { get; set; } = new();
}
