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
        switch (update.Message.Text)
        {
            case BotCommands.UploadPicture : 
                ICommandProcessor commandProcessor = _commandProcessorFactory.GetCommandProcessor();
                    await commandProcessor.Process(update);
                break;
           // case BotCommands.SwapPicture : 
        }
        
       
        
        return Ok();
    }
}   