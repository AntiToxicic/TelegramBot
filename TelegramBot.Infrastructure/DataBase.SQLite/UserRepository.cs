using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;

namespace TelegramBot.Infrastructure.DataBase;


public class UserRepository : IUserRepository
{
    public Task<IReadOnlyCollection<User>> GetUser(int id)
    {
        throw new NotImplementedException();
    }
}