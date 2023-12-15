using Telegram.Bot.Types;

namespace TelegramBot.Telegram.Interfaces;

public interface IAction
{
    public Task ExecuteAsync(Message message);
}