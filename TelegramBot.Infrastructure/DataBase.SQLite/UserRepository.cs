using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.Infrastructure.DataBase.SQLite.Tables;

namespace TelegramBot.Infrastructure.DataBase.SQLite;


public class UserRepository : IUserRepository
{
    public async Task<User> GetUser(long userId)
    {
        return new User(12,"");
    }

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