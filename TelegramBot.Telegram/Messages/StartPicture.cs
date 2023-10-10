using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Telegram.Interfaces;
using TelegramBot.Telegram.Telegram;

namespace TelegramBot.Telegram.Messages;

public class StartPicture : ICommandProcessor
{
    private readonly TelegramBotClient _telegramBotClient;

    public StartPicture(TelegramBotClient telegramBotClient)
    {
        _telegramBotClient = telegramBotClient;
    }
    
    public async Task Process(Update update)
    {
        await _telegramBotClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            text: BotAnswers.start
        );
        
        using (Stream stream = new FileStream("C:/_Alex/Code/TelegramBot/Pictures/FirstPicture.jpg", FileMode.Open))
        {
            await _telegramBotClient.SendPhotoAsync(
                chatId: update.Message.Chat.Id,
                photo: InputFile.FromStream(stream),
                caption: "Первая картинка");
        }
    }
}