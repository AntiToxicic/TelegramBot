using MediatR;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Message.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Queries;
using TelegramBot.Telegram.Interfaces;

namespace TelegramBot.Telegram.Actions;

public class NewPictureExistAction : IExistAction
{
    private readonly IMediator _mediator;
    public event Func<Message, Task>? ExecuteDefault;

    public NewPictureExistAction(IMediator mediator)
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
        
        await _mediator.Send(new SavePictureCommand(
            PicId: message.Photo.Last().FileId,
            Caption: message.Caption,
            UserId: message.Chat.Id));
        await _mediator.Send(new SendMessageCommand(
            Message: BotTextAnswers.ACCEPTPICTURE,
            ChatId: message.Chat.Id,
            Status: Statuses.WATCH));
    }
}