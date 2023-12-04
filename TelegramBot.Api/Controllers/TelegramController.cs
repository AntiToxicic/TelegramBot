using MediatR;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Message.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Queries;
using TelegramBot.Telegram.ActionCommands;

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
        var msg = update.Message!;
        
        Statuses status = (await _mediator.Send(new GetUserCommand(msg.Chat.Id))).Status;
        string? command = msg.Text;
        
        List<ActionCommand> actionCommands = new()
        {
            new START_ActionCommand(_mediator, status, TelegramCommands.START),
            new RULES_ActionCommand(_mediator, status, TelegramCommands.RULES),
            new STATISTIC_ActionCommand(_mediator, status, TelegramCommands.STATICTIC),
            new GETSTART_ActionCommand(_mediator, Statuses.START),
            new LIKE_ActionCommand(_mediator, Statuses.START),
            new GETPICTURE_ActionCommand(_mediator, Statuses.START),
            new UPLOADPICTURE_ActionCommand(_mediator, Statuses.START),
            new GETBACK_ActionCommand(_mediator, Statuses.START)
        };

        ActionCommand wrongCommand = new WRONGANSWER_ActionCommand(_mediator, status);
        
        
        foreach (var e in actionCommands)
        {
            if (e.Command == TelegramCommands.START ||
                e.Command == TelegramCommands.RULES ||
                e.Command == TelegramCommands.STATICTIC)
            {
                await e.Execute(update);
                break;
            }
            
            if (e.Status != status && 
                e.Command == command)  
            
            if (msg.Photo is not null)
            {
                await e.Execute(update);
                break;
            }
            
            if (e.Status == status && 
                e.Command == command) await e.Execute(update);
        }
        
        
        

        
        if (msg.Text == TelegramCommands.START)
        {
            await _mediator.Send(new SaveUserInfoCommand(msg.Chat.Id));
            await _mediator.Send(new SendMessageCommand(
                Message: BotTextAnswers.START,
                ChatId: msg.Chat.Id,
                Status: Statuses.START));
            return Ok();
        }

        if (msg.Text == TelegramCommands.RULES)
        {
            await _mediator.Send(new SendMessageCommand(
                Message: BotTextAnswers.RULES,
                ChatId: msg.Chat.Id,
                Status: status));
            return Ok();
        }
        
        if (msg.Text == TelegramCommands.STATICTIC)
        {
            await _mediator.Send(new SendUserStatisticCommand(
                Message: BotTextAnswers.STATICTIC,
                ChatId: msg.Chat.Id,
                Status: status));
            return Ok();
        }
        
        switch ((int)status)
        {
           case (int)Statuses.START:
               if (msg.Text == TelegramCommands.GETSTART)
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
                        ChatId: msg.Chat.Id));
                else if(msg.Text == TelegramCommands.LIKE)
                {
                    await _mediator.Send(new SendRandomPictureCommand(
                        ChatId: msg.Chat.Id));
                    await _mediator.Send(new IncreasePictureRatingCommand(
                        UserId: msg.Chat.Id));
                }
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
                    await _mediator.Send(new SendMessageCommand(
                        Message: BotTextAnswers.CONTINUE,
                        ChatId: msg.Chat.Id,
                        Status: Statuses.WATCH));
                    await _mediator.Send(new SendRandomPictureCommand(
                        ChatId: msg.Chat.Id));
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