using Telegram.Bot;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;

namespace TelegramBot.Telegram.Common;

public class PictureDownloader : IPictureDownloader
{
    private readonly ITelegramBotClient _botClient;
    private readonly IPictureRepository _pictureRepository;

    public PictureDownloader(ITelegramBotClient botClient, IPictureRepository pictureRepository)
    {
        _botClient = botClient;
        _pictureRepository = pictureRepository;
    }

    public async Task<Picture> DownloadAsync(string picId, string filePath, string caption, long userId)
    {
        var tempPicId = picId.GetHashCode();
        string picPath = await _pictureRepository
                             .GeneratePathAsync(userId) + tempPicId + ".jpg";
        
        await using (FileStream stream = File.Create(picPath))
        {
            await _botClient.DownloadFileAsync(
                filePath: filePath,
                destination: stream
            );
        }

        return new Picture(
            picId: picId,
            path: picPath,
            caption: caption,
            userId: userId)
        {
            Id = tempPicId
        };

    }
    
}