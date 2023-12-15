using MediatR;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Message.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Queries;
using TelegramBot.Telegram.Interfaces;

namespace TelegramBot.Telegram.Actions;

public class GetBackExistAction : IExistAction
{
    private readonly IMediator _mediator;
    public event Func<Message, Task>? ExecuteDefault;

    public GetBackExistAction(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task ExecuteAsync(Message message)
    {
        Statuses status = (await _mediator.Send(new GetUserCommand(message.Chat.Id))).Status;

        if (status is not Statuses.AWAITPICTURE)
        {
            await ExecuteDefault?.Invoke(message)!;
            return;
        }
        
        await _mediator.Send(new SendMessageCommand(
            Message: BotTextAnswers.CONTINUE,
            ChatId: message.Chat.Id,
            Status: Statuses.WATCH));
        await _mediator.Send(new SendRandomPictureCommand(
            ChatId: message.Chat.Id));
    }
}