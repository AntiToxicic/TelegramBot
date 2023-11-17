using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace TelegramBot.Telegram.Controllers;

[ApiController]
[Route("[controller]")]
public class TelegramController : ControllerBase
{
    public TelegramController()
    {
        
    }
    
    [HttpPost("webhook")]
    public async Task<IActionResult> WebHook(Update update)
    {
       
        return Ok();
    }
}   