using MediatR;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Queries;
using TelegramBot.Telegram.Interfaces;
using User = TelegramBot.ApplicationCore.Entities.User;

namespace TelegramBot.Telegram.Actions;

public class GetStartExistAction : IExistAction
{
    private readonly IMediator _mediator;
    public event Func<Message, Task>? ExecuteDefault;
    public event Func<Message, Task>? ExecuteNotRegisteredDefault;

    public GetStartExistAction(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task ExecuteAsync(Message message)
    {
        User? user = await _mediator.Send(new GetUserCommand(message.Chat.Id));

        if (user is null)
        {
            await ExecuteNotRegisteredDefault?.Invoke(message)!;
            return;
        }
        
        Statuses status = user!.Status;
        
        if (status is not Statuses.START)
        {
            await ExecuteDefault?.Invoke(message)!;
            return;
        }
        
        await _mediator.Send(new SendFirstPictureCommand(
            ChatId: message.Chat.Id,
            Status: Statuses.WATCH));
    }
}