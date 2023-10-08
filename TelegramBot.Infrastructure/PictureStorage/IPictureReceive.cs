

using Telegram.Bot.Types;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IPictureReceive
{
    public Task SavePicture(Update update);

}