using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.Infrastructure.Options;
using File = System.IO.File;

namespace TelegramBot.Infrastructure.Services;

public class PictureService : IPictureService
{
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly PictureStorageOptions _pictureStorageOptions;

    public PictureService(ITelegramBotClient telegramBotClient, IOptions<PictureStorageOptions> pictureStorageOptions)
    {
        _telegramBotClient = telegramBotClient;
        _pictureStorageOptions = pictureStorageOptions.Value;
    }

    public async Task<string> DownloadAsync(long chatId, string id, CancellationToken cancellationToken)
    {
        var file = await _telegramBotClient.GetFileAsync(id, cancellationToken);

        if (file is null)
            throw new Exception();
        
        var path = Path.Combine(_pictureStorageOptions.BasePath, file.FilePath!);

        await using var pictureStream = File.Create(path);

        await _telegramBotClient.DownloadFileAsync(file.FilePath!, pictureStream, cancellationToken);

        return path;
    }

    public async Task SendPictureAsync(long chatId, PictureInfo pictureInfo, CancellationToken cancellationToken)
    {
        // TODO: relative path
        var path = Path.Combine(_pictureStorageOptions.BasePath, pictureInfo.UriPath);

        await using var pictureStream = new FileStream(path, FileMode.Open);

        await _telegramBotClient.SendPhotoAsync(
            chatId: chatId,
            photo: InputFile.FromStream(pictureStream),
            caption: pictureInfo.Caption!,
            cancellationToken: cancellationToken);
    }
}
