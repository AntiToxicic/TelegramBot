using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IPictureDownloader
{
    public Task<Picture> DownloadAsync(
        string picId,
        string filePath,
        string caption,
        long userId);
}