using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Services;
using TelegramBot.Infrastructure;

namespace TelegramBot.Telegram.Controllers;

[ApiController]
[Route("[controller]")]
public class TelegramController : ControllerBase
{
    private IPictureReceiveFactory _pictureReceiveFactory;
    
    public TelegramController(IPictureReceiveFactory pictureReceiveFactory)
    {
        _pictureReceiveFactory = pictureReceiveFactory;
    }
    
    [HttpPost("webhook")]
    public async Task<IActionResult> WebHook(Update update)
    {
        IPictureReceive pictureReceive = _pictureReceiveFactory.Process();
        if(update.Message.Photo is {})
            await pictureReceive.SavePicture(update);
        
        return Ok();
    }
}   