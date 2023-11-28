using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IUserRepository
{
    Task AddUserAsync(User user);
    Task<User> GetUserAsync(long chatId);
    Task SetStatusAsync(Statuses status, long chatId);
    Task SetPictureIdForRatingAsync(long picId, long userId);
}