using MediatR;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Message.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Queries;

namespace TelegramBot.Telegram.Controllers;

[ApiController]
[Route("[controller]")]
public class TelegramController : ControllerBase
{
    private readonly IMediator _mediator;

    public TelegramController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("webhook")]
    public async Task<IActionResult> WebHook(Update update)
    {
        Console.WriteLine(BotTextAnswers.CONTINUE +"--------------text");
        var msg = update.Message!;
        Statuses status;

        #region Add a new User and get Status or get Status old User
        if (msg.Text == TelegramCommands.START)
        {
            await _mediator.Send(new SaveUserInfoCommand(msg.Chat.Id));
            await _mediator.Send(new SendMessageCommand(
                Message: BotTextAnswers.START,
                ChatId: msg.Chat.Id,
                Status: Statuses.START));
            status = Statuses.START;
        } 
        else
            status = await _mediator.Send(new GetUserStatusCommand(msg.Chat.Id));
        #endregion

        if (msg.Text == TelegramCommands.RULES)
        {
            await _mediator.Send(new SendMessageCommand(
                Message: BotTextAnswers.RULES,
                ChatId: msg.Chat.Id,
                Status: status));
            return Ok();
        }
        
        
        switch ((int)status)
        {
           case (int)Statuses.START:
               if (msg.Text == TelegramCommands.OK)
                   await _mediator.Send(new SendFirstPictureCommand(
                       ChatId: msg.Chat.Id,
                       Status: Statuses.WATCH));
               else
                   await _mediator.Send(new SendMessageCommand(
                       Message: BotTextAnswers.WRONGANSWER,
                       ChatId: msg.Chat.Id,
                       Status: status));
               break;
            
            case (int)Statuses.WATCH: 
                if(msg.Text == TelegramCommands.GETPICUTRE)
                    await _mediator.Send(new SendRandomPictureCommand(
                        chatId: msg.Chat.Id));
                else if (msg.Text == TelegramCommands.UPLOADPICTURE)
                    await _mediator.Send(new SendMessageCommand(
                        Message: BotTextAnswers.AWAITPICTURE,
                        ChatId: msg.Chat.Id,
                        Status: Statuses.AWAITPICTURE));
                else
                    await _mediator.Send(new SendMessageCommand(
                        Message: BotTextAnswers.WRONGANSWER,
                        ChatId: msg.Chat.Id,
                        Status: status));
                break;
            
            case (int)Statuses.AWAITPICTURE:
                if (msg.Photo is not null)
                {
                    await _mediator.Send(new SavePictureCommand(
                        PicId: msg.Photo.Last().FileId,
                        Caption: msg.Caption,
                        UserId: msg.Chat.Id));
                    await _mediator.Send(new SendMessageCommand(
                        Message: BotTextAnswers.ACCEPTPICTURE,
                        ChatId: msg.Chat.Id,
                        Status: Statuses.WATCH));
                } 
                else if (msg.Text == TelegramCommands.GETBACK)
                {
                    Console.WriteLine(BotTextAnswers.CONTINUE + "==== countinue");
                    await _mediator.Send(new SendMessageCommand(
                        Message: BotTextAnswers.CONTINUE,
                        ChatId: msg.Chat.Id,
                        Status: Statuses.WATCH));
                    await _mediator.Send(new SendRandomPictureCommand(
                        chatId: msg.Chat.Id));
                }
                else
                    await _mediator.Send(new SendMessageCommand(
                        Message: BotTextAnswers.WRONGANSWER,
                        ChatId: msg.Chat.Id,
                        Status: status));
                break;
        }
        
        return Ok();
    }
}   