using Microsoft.EntityFrameworkCore;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.Infrastructure.DataBase.SQLite.Tables;

namespace TelegramBot.Infrastructure.DataBase.SQLite;

public class PictureRepository : IPictureRepository
{
    public async Task<Picture> GetPicture()
    {
        Random random = new ();
        
        long id;
        string path, caption;
        int tempCount;
        
        using (DBSQLiteContex db = new DBSQLiteContex())
        {
            // Console.WriteLine(db.ToString());
            var tempList = await db.Pictures.ToListAsync();
            tempCount = random.Next(tempList.Count);
            
            id = tempList[tempCount].Id;
            path = tempList[tempCount].Path;
            caption = tempList[tempCount].Caption;
        }
        
        Console.WriteLine($"id = {id}\npath = {path}\ncaption = {caption}");
        
        return new Picture(
            id: id,
            path: path,
            caption: caption);
       // return new Picture(1, "sd", "23");
    }

    public async Task RecordPicture(long picId, long userId, string picPath, string caption = "Без подписи")
    {
        PictureDBTable pic = new(picId, userId, picPath, caption);
        
        using (DBSQLiteContex db = new DBSQLiteContex())
        {
            db.Pictures.AddRange(pic);
            db.SaveChanges();
        }
    }
}