using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IUserInfoReceiving
{
    Task<User> GetUserInfoAsync(long chatId);
}