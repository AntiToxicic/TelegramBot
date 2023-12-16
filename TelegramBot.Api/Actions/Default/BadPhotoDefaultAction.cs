using MediatR;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Message.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Queries;
using TelegramBot.Telegram.Interfaces;

namespace TelegramBot.Telegram.Actions;

public class BadPhotoDefaultAction : IAction
{
    private readonly IMediator _mediator;
    
    public BadPhotoDefaultAction(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task ExecuteAsync(Message message)
    {
        Statuses status = (await _mediator.Send(new GetUserCommand(message.Chat.Id))).Status;
        
        await _mediator.Send(new SendMessageCommand(
            Message: BotTextAnswers.BADPHOTODEFAULT,
            ChatId: message.Chat.Id,
            Status: status));
    }
}