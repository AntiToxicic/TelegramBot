using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserAsync(long chatId, CancellationToken cancellationToken);
    Task AddUserAsync(User user, CancellationToken cancellationToken);

    Task UpdateLastReceivedPictureInfoIdAsync(User user, long lastReceivedPictureInfoId, CancellationToken cancellationToken);
}
