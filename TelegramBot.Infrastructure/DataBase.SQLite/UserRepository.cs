using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;

namespace TelegramBot.Infrastructure.DataBase.SQLite;


public class UserRepository : IUserRepository
{
    public async Task<User> GetUser(long userId)
    {
        return new User("");
    }

    public async Task RecordUser(long userId, string userName)
    {
        
    }
}