using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IPictureService
{
    public Task<Picture> GetPicture();
    public Task<Picture> GetPicture(long id);
    public Task RecordPicture(long picId, long userId, string picPath, string caption = "Без подписи");
}