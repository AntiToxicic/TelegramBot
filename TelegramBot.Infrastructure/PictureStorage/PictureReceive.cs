using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Services;
using TelegramBot.Infrastructure.DataBase.Tables;

namespace TelegramBot.Infrastructure.PictureStorage;

public class PictureReceive : IPictureReceive
{
    private TelegramBotClient _botClient;
    
    public PictureReceive(TelegramBotClient telegramBotClient)
    {
        _botClient = telegramBotClient;
    }
    public async Task SavePicture(Update update)
    {
        
        Random random = new();
        string tempPath;
        string tempName;
        long tempId = random.NextInt64();

        using (DBSQLiteContex db = new DBSQLiteContex())
        {
            tempName = tempId + ".jpg";
            tempPath = $@"C:/_Alex/Code/TelegramBot/Pictures/{update.Message.Chat.Id}/";
            
            PictureDBTable pic = new(tempPath + tempName){Id = tempId};
           
            db.Picture.AddRange(pic);
            foreach (var e in db.Users.ToList())
            {
                if (e.Id == update.Message.Chat.Id)
                    break;
                
                UserDBTable user = new(update.Message.Chat.Username) { Id = update.Message.Chat.Id, picture = pic};
                db.Users.AddRange(user);
            }
            
            db.SaveChanges();
        }

        var fileId = update.Message.Photo.Last().FileId;
        var fileInfo = await _botClient.GetFileAsync(fileId);
        var filePath = fileInfo.FilePath;

        Directory.CreateDirectory(tempPath);
        
        await using
            (Stream stream = System.IO.File.Create(tempPath + tempName))
        {
            await _botClient.DownloadFileAsync(
                filePath: filePath,
                destination: stream
            );
            
        }
        
        await _botClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            text: "Спасибо за фоточку");
            
        
   
        var me = await _botClient.GetMeAsync();
        Console.WriteLine($"----------------  {me}");
        
    }
}