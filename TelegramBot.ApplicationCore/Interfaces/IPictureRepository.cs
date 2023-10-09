using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IPictureRepository
{
    public Task<Picture> GetPicture(long picId);
    public Task RecordPicture(long chatId, long picId, string userName, string caption);
}