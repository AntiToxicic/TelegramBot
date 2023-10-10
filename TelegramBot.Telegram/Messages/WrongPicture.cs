using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Telegram.Interfaces;
using TelegramBot.Telegram.Telegram;

namespace TelegramBot.Telegram.Messages;

public class WrongPicture : ICommandProcessor
{
    private readonly TelegramBotClient _telegramBotClient;

    public WrongPicture(TelegramBotClient telegramBotClient)
    {
        _telegramBotClient = telegramBotClient;
    }
    
    public async Task Process(Update update)
    {
        await _telegramBotClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            text: BotAnswers.wrongPicture
            );
    }
}