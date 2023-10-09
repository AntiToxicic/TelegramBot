using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.Telegram.Interfaces;

namespace TelegramBot.Infrastructure;

public interface ICommandProcessorFactory
{
    public ICommandProcessor GetCommandProcessor();
}