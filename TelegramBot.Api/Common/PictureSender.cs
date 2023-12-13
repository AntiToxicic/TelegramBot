using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.Telegram.Interfaces;

namespace TelegramBot.Telegram.Common;

public class PictureSender : IPictureSender
{
    private readonly ITelegramBotClient _botClient;
    private readonly IKeyboardMarkupConstructor _markupConstructor;

    public PictureSender(ITelegramBotClient botClient, IKeyboardMarkupConstructor markupConstructor)
    {
        _botClient = botClient;
        _markupConstructor = markupConstructor;
    }

    public async Task SendPictureAsync(Picture picture, long chatId, Statuses status)
    {
        var markup = _markupConstructor.GetMarkup(status);
        string rating = BotTextAnswers.NOLIKES;

        if (picture.Rating != 0) 
            rating = BotTextAnswers.LIKESCOUNT + picture.Rating;
            
        string caption = $"{picture.Caption}\n\n" +
                         $"{rating}";
        
        using (Stream stream = new FileStream(picture.Path, FileMode.Open))
        {
            await _botClient.SendPhotoAsync(
                chatId: chatId,
                photo: InputFile.FromStream(stream),
                caption: caption,
                replyMarkup: markup);
        }
    }
}