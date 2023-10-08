using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IPictureService
{
    public Task<Picture> GetPicture(int id);
    public Task<IReadOnlyCollection<Picture>> SendPicture(int id);
 //   public Task SavePicture(Update update);
}