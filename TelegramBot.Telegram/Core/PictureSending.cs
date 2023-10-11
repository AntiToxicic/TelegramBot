using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.Telegram.Interfaces;

namespace TelegramBot.Telegram.Core;

public class PictureSending : ICommandProcessor
{
    private readonly TelegramBotClient _botClient;
    private readonly IPictureService _pictureService;
    
    public PictureSending(TelegramBotClient telegramBotClient,
         IPictureService pictureService)
    {
        _botClient = telegramBotClient;
        _pictureService = pictureService;
    }
    public async Task Process(Update update)
    {
        Picture picture = await _pictureService.GetPicture();

        using (Stream stream = new FileStream(picture.Path, FileMode.Open))
        {
           await _botClient.SendPhotoAsync(
                chatId: update.Message.Chat.Id,
                photo: InputFile.FromStream(stream),
                caption: picture.Caption);
        }
    }
}