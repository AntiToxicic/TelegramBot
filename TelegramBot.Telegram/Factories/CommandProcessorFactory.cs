using System.Diagnostics;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.Infrastructure;
using TelegramBot.Infrastructure.PictureStorage;
using TelegramBot.Telegram.Core;
using TelegramBot.Telegram.Interfaces;

namespace TelegramBot.Telegram.Factories;

public class CommandProcessorFactory : ICommandProcessorFactory
{
    private IServiceProvider _serviceProvider;

    public CommandProcessorFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ICommandProcessor GetCommandProcessor()
    {
        return _serviceProvider.GetRequiredService<PictureReceiving>();
    }
}