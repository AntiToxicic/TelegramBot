using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IPictureDownloader
{
    public Task<Picture> DownloadAsync(
        string picId,
        string? caption,
        long userId);
}