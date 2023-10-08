using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IPictureRepository
{
    public Task<Picture> GetPicture(int id);
}