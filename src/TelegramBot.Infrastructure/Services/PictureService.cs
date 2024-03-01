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
    private readonly ITelegramBotClient _botClient;
    private readonly PictureStorageOptions _pictureStorageOptions;

    public PictureService(ITelegramBotClient botClient, IOptions<PictureStorageOptions> pictureStorageOptions)
    {
        _botClient = botClient;
        _pictureStorageOptions = pictureStorageOptions.Value;
    }

    public async Task<string> DownloadAsync(long chatId, string id, CancellationToken cancellationToken)
    {
        var file = await _botClient.GetFileAsync(id, cancellationToken);

        if (file is null)
            throw new Exception();
        
        var path = Path.Combine(_pictureStorageOptions.BasePath, file.FilePath!);

        await using var pictureStream = File.Create(path);

        await _botClient.DownloadFileAsync(file.FilePath!, pictureStream, cancellationToken);

        return path;
    }

    public async Task SendPictureAsync(long chatId, Picture picture, CancellationToken cancellationToken)
    {
        // TODO: relative path
        var path = Path.Combine(_pictureStorageOptions.BasePath, picture.UriPath);

        await using var pictureStream = new FileStream(path, FileMode.Open);

        await _botClient.SendPhotoAsync(
            chatId: chatId,
            photo: InputFile.FromStream(pictureStream),
            caption: picture.Caption!,
            cancellationToken: cancellationToken);
    }
}
