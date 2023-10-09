using Telegram.Bot.Types;

namespace TelegramBot.Telegram.Interfaces;

public interface ICommandProcessor
{
    public Task Process(Update update);

}