using MediatR;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Message.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Queries;
using TelegramBot.Telegram.Interfaces;
using User = TelegramBot.ApplicationCore.Entities.User;

namespace TelegramBot.Telegram.Actions;

public class UploadPictureExistAction : IExistAction
{
    private readonly IMediator _mediator;
    public event Func<Message, Task>? ExecuteDefault;
    public event Func<Message, Task>? ExecuteNotRegisteredDefault;

    public UploadPictureExistAction(IMediator mediator)
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
        
        if (status is not Statuses.WATCH)
        {
            await ExecuteDefault?.Invoke(message)!;
            return;
        }
        
        await _mediator.Send(new SendMessageCommand(
            Message: BotTextAnswers.AWAITPICTURE,
            ChatId: message.Chat.Id,
            Status: Statuses.AWAITPICTURE));
    }
}