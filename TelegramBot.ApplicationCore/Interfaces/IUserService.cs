using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IUserService
{
    public Task<User> GetUser(long userId);
    public Task RecordUser(long userId, string userName);
}