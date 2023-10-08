using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.Infrastructure.DataBase.Tables;

public class PictureDBTable : Picture
{
    public PictureDBTable(){}
    public PictureDBTable(string path, string caption = "") : base(path, caption) { }
    
    public List<UserDBTable> UserID { get; set; } = new();
}
