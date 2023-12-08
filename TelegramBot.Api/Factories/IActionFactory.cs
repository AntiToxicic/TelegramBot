using Telegram.Bot.Types;
using TelegramBot.Telegram.Interfaces;

namespace TelegramBot.Telegram.Factories;

public interface IActionFactory
{
    IAction GetAction(Message message);
}