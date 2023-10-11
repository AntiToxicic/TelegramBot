using Microsoft.EntityFrameworkCore;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.Infrastructure.DataBase.SQLite.Tables;

namespace TelegramBot.Infrastructure.DataBase.SQLite;

public class PictureRepository : IPictureRepository
{
    /// <summary>
    /// Get random Picture from Db
    /// </summary>
    public async Task<Picture> GetPicture()
    {
        Picture picture;
        Random random = new ();
        
        using (DBSQLiteContex db = new DBSQLiteContex())
        {
            var tempList = await db.Pictures.ToListAsync();
            int tempCount = random.Next(tempList.Count);

            picture = tempList[tempCount];
        }

        return picture;
    }
    
    /// <summary>
    /// Get certain Picture from Db by id
    /// </summary>
    public async Task<Picture> GetPicture(long picId)
    {
        Picture picture;
        
        using (DBSQLiteContex db = new DBSQLiteContex())
        {
            var tempList = await db.Pictures.ToListAsync();

            picture = tempList.Find(e => e.Id == picId);
        }

        return picture;
    }

    /// <summary>
    /// Record data about Picture in Db
    /// </summary>
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