using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Telegram.Controllers;

[ApiController]
[Route("[controller]")]
public class TelegramController : ControllerBase
{
    private ITelegramBotClient _telegramBotClient;
    public TelegramController()
    {
        
    }
    
    [HttpPost("webhook")]
    public async Task<IActionResult> WebHook(Update update)
    {
        var updates = await _telegramBotClient.GetUpdatesAsync(limit:100);
        var updateId = update.Message.MessageId;
        var chatId = update.Message.Chat.Id;

        var previosUpdate = updates.ToList().FirstOrDefault(c => c.Message.MessageId == updateId - 1);
        var lastMsg = previosUpdate.Message.Text;

        if (lastMsg == ...)
        {
            ...
        }
       
        return Ok();
    }
}   