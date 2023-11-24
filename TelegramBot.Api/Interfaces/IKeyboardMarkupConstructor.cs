using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.ApplicationCore;

namespace TelegramBot.Telegram.Interfaces;

public interface IKeyboardMarkupConstructor
{
    ReplyKeyboardMarkup GetMarkup(Statuses statuses);
}