﻿using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.Telegram.Interfaces;
using User = TelegramBot.ApplicationCore.Entities.User;

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

    public async Task SendPictureAsync(Picture picture, long chatId, Statuses status, int? messageThread = null, User? user = null)
    {
        ReplyKeyboardMarkup? markup = null;
        string? caption = picture.Caption;
        
        
        if (messageThread is null || user is null)
        {
            markup = _markupConstructor.GetMarkup(status);
            string rating = BotTextAnswers.NOLIKES;

            if (picture.Likes is not null) 
                rating = BotTextAnswers.LIKESCOUNT + picture.Likes.Count;
            
            caption += $"\n\n" +
                             $"{rating}";
        }
        else
        {
                caption += $"\n<pre><code class=Уведомления>\nПользователь \"{user.Name}\" добавил картинку</code></pre>";
        }
        
        using (Stream stream = new FileStream(picture.Path, FileMode.Open))
        {
            await _botClient.SendPhotoAsync(
                chatId: chatId,
                messageThreadId: messageThread,
                parseMode: ParseMode.Html,
                photo: InputFile.FromStream(stream),
                caption: caption,
                replyMarkup: markup);
        }
    }
}