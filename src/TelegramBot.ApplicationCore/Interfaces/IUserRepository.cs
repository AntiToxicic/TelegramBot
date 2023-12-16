using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IUserRepository
{
    Task<User> GetOrCreate(long chatId, string name, CancellationToken cancellationToken);

    Task UpdateLastReceivedPictureInfoId(long userId, long lastReceivedPictureInfoId, CancellationToken cancellationToken);
}
