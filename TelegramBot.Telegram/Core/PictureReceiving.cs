using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Services;
using TelegramBot.Telegram.Interfaces;
using TelegramBot.Telegram.Telegram;

namespace TelegramBot.Telegram.Core;

public class PictureReceiving : ICommandProcessor
{
    private TelegramBotClient _botClient;
    private IConfiguration _configuration;
    private IPictureService _pictureService;
    
    public PictureReceiving(TelegramBotClient telegramBotClient,
        IConfiguration configuration)
    {
        _botClient = telegramBotClient;
        _configuration = configuration;
    }
    public async Task Process(Update update)
    {
        Random random = new();
        long picId = random.NextInt64();

        var fileId = update.Message.Photo.Last().FileId;
        var fileInfo = await _botClient.GetFileAsync(fileId);
        var filePath = fileInfo.FilePath;
        
        string picPath = $@"
            {_configuration.GetSection("PictureStorage").GetValue<string>("path")}
            /{update.Message.Chat.Id}/";
        string picName = picId + ".jpg";

        Directory.CreateDirectory(picPath);
        
        await using (Stream stream = System.IO.File.Create(picPath + picName))
        {
            await _botClient.DownloadFileAsync(
                filePath: filePath,
                destination: stream
            );
            
        }

        _pictureService.RecordPicture(
            chatId: update.Message.Chat.Id,
            picId: picId,
            userName: update.Message.Chat.Username,
            caption: update.Message.Text
        );
        
        await _botClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            text: BotAnswers.goodPicture);
    }
}