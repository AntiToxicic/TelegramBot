using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface ILikeRepository
{
    Task AddIfNotExistAsync(Like like, CancellationToken cancellationToken);
}
