using Telegram.Bot.Types;

namespace TelegramBot.Telegram.Interfaces;

public interface IExistAction : IAction
{
    public event Func<Message, Task> ExecuteDefault;
}