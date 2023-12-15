using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IPictureSender
{
    Task SendPictureAsync(
        Picture picture, 
        long chatId,
        Statuses status);
}