using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Telegram.Interfaces;
using TelegramBot.Telegram.Telegram;

namespace TelegramBot.Telegram.Messages;

public class StartPicture : ICommandProcessor
{
    private readonly TelegramBotClient _telegramBotClient;
    private readonly IConfiguration _configuration;

    public StartPicture(TelegramBotClient telegramBotClient, IConfiguration configuration)
    {
        _telegramBotClient = telegramBotClient;
        _configuration = configuration;
    }
    
    public async Task Process(Update update)
    {
        ReplyKeyboardMarkup replyKeyboardMarkup =new(new[]
            {
                new KeyboardButton[] {"Да", "Нет"}
            }) { ResizeKeyboard = true };
        
        await _telegramBotClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            text: BotAnswers.start,
            replyMarkup: replyKeyboardMarkup
        );
        
        using (Stream stream = new FileStream(
                   _configuration.GetSection("PictureStorage").GetValue<string>("StartPicture"),
                   FileMode.Open))
        {
            await _telegramBotClient.SendPhotoAsync(
                chatId: update.Message.Chat.Id,
                photo: InputFile.FromStream(stream),
                caption: "Первая картинка");
        }
    }
}