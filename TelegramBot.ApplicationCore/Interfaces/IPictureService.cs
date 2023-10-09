using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IPictureService
{
    public Task<Picture> GetPicture(long picId);
    public Task RecordPicture(long chatId, long picId, string userName, string caption);
}