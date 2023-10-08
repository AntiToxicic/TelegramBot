using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IPictureTransfer
{
    public Task<IReadOnlyCollection<Picture>> SendPicture(int id);
}