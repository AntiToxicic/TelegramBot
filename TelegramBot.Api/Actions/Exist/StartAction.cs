using MediatR;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Message.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Queries;
using TelegramBot.Telegram.Interfaces;
using User = TelegramBot.ApplicationCore.Entities.User;

namespace TelegramBot.Telegram.Actions;

public class StartAction : IExistAction
{
    private readonly IMediator _mediator;
    public event Func<Message, Task>? ExecuteDefault;
    public event Func<Message, Task>? ExecuteNotRegisteredDefault;

    public StartAction(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task ExecuteAsync(Message message)
    {
        User? user = await _mediator.Send(new GetUserCommand(message.Chat.Id));

        if (user is not null)
        {
            if (user.Status == Statuses.BANNED)
            {
                await ExecuteDefault?.Invoke(message)!;
                return;
            }
        }
        
        await _mediator.Send(new SaveUserInfoCommand(message.Chat.Id));
        await _mediator.Send(new SendMessageCommand(
            Message: BotTextAnswers.START,
            ChatId: message.Chat.Id,
            Status: Statuses.START));
    }
}