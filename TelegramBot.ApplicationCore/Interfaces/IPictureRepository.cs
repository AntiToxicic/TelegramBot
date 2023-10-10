using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IPictureRepository
{
    public Task<Picture> GetPicture();
    public Task RecordPicture(long picId, long userId, string picPath, string caption = "Без подписи");
}