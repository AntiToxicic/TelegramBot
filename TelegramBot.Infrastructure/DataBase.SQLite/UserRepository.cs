using Microsoft.EntityFrameworkCore;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.Infrastructure.DataBase.SQLite.Tables;

namespace TelegramBot.Infrastructure.DataBase.SQLite;


public class UserRepository : IUserRepository
{
    /// <summary>
    /// Get certain User by id
    /// </summary>
    public async Task<User> GetUser(long userId)
    {
        User tempUser;
        long id;
        string name;
        
        await using (DBSQLiteContex db = new DBSQLiteContex())
        {
            tempUser = db.Users.ToList().Find(e => e.Id ==userId);
        }

        return tempUser;
    }

    /// <summary>
    /// Record data about User in Db
    /// </summary>
    public async Task RecordUser(long userId, string userName)
    {
        UserDBTable user = new(userId, userName);
        
        using (DBSQLiteContex db = new DBSQLiteContex())
        {
            foreach (var e in db.Users.ToList())
            {
                if (e.Id == userId) return;
            }

            db.Users.AddRange(user);

            db.SaveChanges();
        }
    }
}