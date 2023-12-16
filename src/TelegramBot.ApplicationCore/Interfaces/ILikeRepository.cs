using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface ILikeRepository
{
    Task<bool> AddIfNotExistAsync(Like like, CancellationToken cancellationToken);
}
