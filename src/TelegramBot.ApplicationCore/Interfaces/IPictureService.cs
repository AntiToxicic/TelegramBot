using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IPictureService
{
    Task<string> DownloadAsync(long chatId, string id, CancellationToken cancellationToken);

    Task SendPictureAsync(long chatId, PictureInfo picture, CancellationToken cancellationToken);
}
