using TelegramBot.Infrastructure;
using TelegramBot.Telegram.Core;
using TelegramBot.Telegram.Interfaces;
using TelegramBot.Telegram.Messages;
using TelegramBot.Telegram.Telegram;

namespace TelegramBot.Telegram.Factories;

public class CommandProcessorFactory : ICommandProcessorFactory
{
    private IServiceProvider _serviceProvider;

    public CommandProcessorFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ICommandProcessor GetCommandProcessor(string text)
    {
        
        
        switch (text)
        {
            case BotCommandsExtenitons.wrongPictureUpload: return _serviceProvider.GetRequiredService<WrongPicture>();
            case BotCommands.KeyToReceive: return _serviceProvider.GetRequiredService<PictureReceiving>();
            case BotCommands.SwapPicture: return _serviceProvider.GetRequiredService<PictureSending>();
            case BotCommands.UploadPicture: return _serviceProvider.GetRequiredService<WaitingPicture>();
            case BotCommands.start: return _serviceProvider.GetRequiredService<StartPicture>();
            case BotCommands.rules: return _serviceProvider.GetRequiredService<Rules>();
            default: return _serviceProvider.GetRequiredService<WrongPicture>();
        }
    }
}