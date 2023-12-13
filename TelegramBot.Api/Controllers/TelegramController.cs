using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegramBot.Telegram.Factories;

namespace TelegramBot.Telegram.Controllers;

[ApiController]
[Route("[controller]")]
public class TelegramController : ControllerBase
{
    private readonly IActionFactory _actionFactory;

    public TelegramController(IActionFactory actionFactory)
    {
        _actionFactory = actionFactory;
    }

    [HttpPost("webhook")]
    public async Task<IActionResult> WebHook(Update update)
    {
        var action = _actionFactory.GetAction(update.Message);
        
        await action.ExecuteAsync(update.Message);
        
        return Ok();
    }
}   