using MediatR;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Message.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Queries;
using TelegramBot.Telegram.Interfaces;
using User = TelegramBot.ApplicationCore.Entities.User;

namespace TelegramBot.Telegram.Actions;

public class BanUserAction : IExistAction
{
    private readonly IMediator _mediator;

    public BanUserAction(IMediator mediator)
    {
        _mediator = mediator;
    }

    public event Func<Message, Task>? ExecuteDefault;
    public event Func<Message, Task>? ExecuteNotRegisteredDefault;
    
    public async Task ExecuteAsync(Message message)
    {
        User? user = await _mediator.Send(new GetUserCommand(message.Chat.Id));

        if (user is null)
        {
            await ExecuteNotRegisteredDefault?.Invoke(message)!;
            return;
        }

        if (user.Name is not "AntiToxicic")
        {
            await ExecuteDefault?.Invoke(message)!;
            return;
        }
        
        Statuses status = user!.Status;
        
        if (status is not Statuses.WATCH)
        {
            await ExecuteDefault?.Invoke(message)!;
            return;
        }

        var bannedUser = await _mediator.Send(new BanUserCommand(message.Chat.Id));
        await _mediator.Send(new DeleteAllUserPicturesCommand(message.Chat.Id));

        await _mediator.Send(new SendMessageCommand(BotTextAnswers.USERWASBANNED, message.Chat.Id, user.Status));
        await _mediator.Send(new SendMessageCommand(BotTextAnswers.YOUWEREBANNED, bannedUser.Id, Statuses.BANNED));
        
        await _mediator.Send(new SendRandomPictureCommand(
            ChatId: message.Chat.Id));
    }

}