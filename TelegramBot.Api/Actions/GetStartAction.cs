using MediatR;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Queries;
using TelegramBot.Telegram.Interfaces;

namespace TelegramBot.Telegram.Actions;

public class GetStartAction : IAction
{
    private readonly IMediator _mediator;
    public event Func<Message, Task>? ExecuteDefault;

    public GetStartAction(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task ExecuteAsync(Message message)
    {
        Statuses status = (await _mediator.Send(new GetUserCommand(message.Chat.Id))).Status;

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