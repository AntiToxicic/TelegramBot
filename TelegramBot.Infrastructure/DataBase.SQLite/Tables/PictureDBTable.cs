using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.Infrastructure.DataBase.SQLite.Tables;

public class PictureDBTable : Picture
{
  //  public PictureDBTable(){}
    public PictureDBTable(string path, string caption = "") : base(path, caption) { }
    
    public long UserId { get; set; }
    public UserDBTable User { get; set; }
    
   // public List<UserDBTable> UserID { get; set; } = new();
}
