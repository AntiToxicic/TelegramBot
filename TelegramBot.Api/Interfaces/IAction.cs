using Telegram.Bot.Types;
using TelegramBot.Telegram.Actions;

namespace TelegramBot.Telegram.Interfaces;

public interface IAction
{
    public event Func<Message, Task> ExecuteDefault;
    
    Task ExecuteAsync(Message message);
}