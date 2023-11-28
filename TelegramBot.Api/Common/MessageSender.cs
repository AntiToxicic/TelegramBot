using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.Telegram.Interfaces;

namespace TelegramBot.Telegram.Common;

public class MessageSender : IMessageSender
{
    private readonly ITelegramBotClient _botClient;
    private readonly IKeyboardMarkupConstructor _markupConstructor;

    public MessageSender(ITelegramBotClient botClient, IKeyboardMarkupConstructor markupConstructor)
    {
        _botClient = botClient;
        _markupConstructor = markupConstructor;
    }

    public async Task SendMessage(string message, long chatId, Statuses status)
    {
        var markup = _markupConstructor.GetMarkup(status);
        
        await _botClient.SendTextMessageAsync(
            chatId: chatId,
            text: message,
            replyMarkup: markup);
    }
}