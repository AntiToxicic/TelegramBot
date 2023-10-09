using Microsoft.Extensions.Configuration;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.Infrastructure.DataBase.SQLite.Tables;

namespace TelegramBot.Infrastructure.DataBase.SQLite;

public class PictureRepository : IPictureRepository
{
    public async Task<Picture> GetPicture(long chatId)
    {
        return new Picture();
    }

    public async Task RecordPicture(long picId, long chatId, string picPath, string caption)
    {
        using (DBSQLiteContex db = new DBSQLiteContex())
        {
            UserDBTable user = new(userName) { Id = chatId };

            foreach (var e in db.Users.ToList())
            {
                if (e.Id == chatId)
                    break;

                db.Users.AddRange(user);
            }
         
            PictureDBTable pic = new(picPath){Id = picId, UserId = user.Id};
            
            db.Pictures.AddRange(pic);
            
            db.SaveChanges();
        }
    }
}