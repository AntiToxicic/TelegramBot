using MediatR;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Message.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Commands;
using TelegramBot.Telegram.Interfaces;

namespace TelegramBot.Telegram.Actions;

public class StartExistAction : IExistAction
{
    private readonly IMediator _mediator;
    public event Func<Message, Task>? ExecuteDefault;
    public event Func<Message, Task>? ExecuteNotRegisteredDefault;

    public StartExistAction(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task ExecuteAsync(Message message)
    {
        await _mediator.Send(new SaveUserInfoCommand(message.Chat.Id));
        await _mediator.Send(new SendMessageCommand(
            Message: BotTextAnswers.START,
            ChatId: message.Chat.Id,
            Status: Statuses.START));
    }
}