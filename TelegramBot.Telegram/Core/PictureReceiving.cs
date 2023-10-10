using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.Telegram.Interfaces;
using TelegramBot.Telegram.Telegram;

namespace TelegramBot.Telegram.Core;

public class PictureReceiving : ICommandProcessor
{
    private readonly TelegramBotClient _botClient;
    private readonly IConfiguration _configuration;
    private readonly IPictureService _pictureService;
    private readonly IUserService _userService;
    
    public PictureReceiving(TelegramBotClient telegramBotClient,
        IConfiguration configuration, IPictureService pictureService,
        IUserService userService)
    {
        _botClient = telegramBotClient;
        _configuration = configuration;
        _pictureService = pictureService;
        _userService = userService;
    }
    public async Task Process(Update update)
    {
        Random random = new();
        long picId = random.NextInt64();

        var fileId = update.Message.Photo.Last().FileId;
        var fileInfo = await _botClient.GetFileAsync(fileId);
        var filePath = fileInfo.FilePath;
        
        string picPath = $@"{_configuration.GetSection("PictureStorage").GetValue<string>("path")}{update.Message.Chat.Id}/";
        string picName = picId + ".jpg";

        Directory.CreateDirectory(picPath);
        
        await using (Stream stream = System.IO.File.Create(picPath + picName))
        {
            await _botClient.DownloadFileAsync(
                filePath: filePath,
                destination: stream
            );
        }

        await _userService.RecordUser(
            userId: update.Message.Chat.Id,
            userName: update.Message.Chat.Username
        );
        
        await _pictureService.RecordPicture(
            userId: update.Message.Chat.Id,
            picId: picId,
            picPath: picPath + picName,
            caption: update.Message.Text
        );
        
        await _botClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            text: BotAnswers.goodPicture);
    }
}