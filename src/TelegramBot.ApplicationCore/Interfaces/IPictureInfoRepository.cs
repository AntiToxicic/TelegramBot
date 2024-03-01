using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IPictureInfoRepository
{
    Task AddAsync(Picture picture, CancellationToken cancellationToken);
    Task<Picture?> GetRandomPictureAsync(CancellationToken cancellationToken);
}
