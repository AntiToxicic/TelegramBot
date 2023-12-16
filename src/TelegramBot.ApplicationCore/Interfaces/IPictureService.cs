using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IPictureService
{
    Task<string> Download(string id, CancellationToken cancellationToken);

    Task Send(long chatId, PictureInfo picture, CancellationToken cancellationToken);
}
