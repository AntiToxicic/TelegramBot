using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;

namespace TelegramBot.Infrastructure.PictureStorage;

public class PictureTransfer : IPictureTransfer
{
    public Task<IReadOnlyCollection<Picture>> SendPicture(int id)
    {
        throw new NotImplementedException();
    }
}