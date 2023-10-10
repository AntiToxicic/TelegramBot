using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegramBot.Infrastructure;
using TelegramBot.Telegram.Interfaces;
using TelegramBot.Telegram.Telegram;

namespace TelegramBot.Telegram.Controllers;

[ApiController]
[Route("[controller]")]
public class TelegramController : ControllerBase
{
    private readonly ICommandProcessorFactory _commandProcessorFactory;
    
    public TelegramController(ICommandProcessorFactory commandProcessorFactory)
    {
        _commandProcessorFactory = commandProcessorFactory;
    }
    
    [HttpPost("webhook")]
    public async Task<IActionResult> WebHook(Update update)
    {
        ICommandProcessor commandProcessor;

        if (update.Message.Photo is { })
        {
            if (LastMessage.GetMessage(update.Message.Chat.Id) == BotCommands.UploadPicture)
            {
                commandProcessor = _commandProcessorFactory.GetCommandProcessor(
                    BotCommands.KeyToReceive);
            }
            else
            {
                commandProcessor = _commandProcessorFactory.GetCommandProcessor(
                    BotCommandsExtenitons.wrongPictureUpload);
            }
        }
        else
        {
            commandProcessor = _commandProcessorFactory.GetCommandProcessor(update.Message.Text);
        }
        
        await commandProcessor.Process(update);
        
        LastMessage.SaveMessage(update.Message.Chat.Id, update.Message.Text);
        
        return Ok();
    }
}   