using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IUserService
{
    public Task<IReadOnlyCollection<User>> GetUser(int id);
}