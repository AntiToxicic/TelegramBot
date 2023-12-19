using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IPictureInfoRepository
{
    Task AddAsync(PictureInfo picture, CancellationToken cancellationToken);
    Task<PictureInfo?> Random(CancellationToken cancellationToken);
}
