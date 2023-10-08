using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IUserRepository
{
    public Task<IReadOnlyCollection<User>> GetUser(int id);
}