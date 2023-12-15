using MediatR;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Message.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Queries;
using TelegramBot.Telegram.Interfaces;
using User = TelegramBot.ApplicationCore.Entities.User;

namespace TelegramBot.Telegram.Actions;

public class DefaultAction : IDefaultAction
{
    private readonly IMediator _mediator;
    
    public DefaultAction(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task ExecuteAsync(Message message)
    {
        User? user = await _mediator.Send(new GetUserCommand(message.Chat.Id));

        if (user is null)
        {
            await new NotRegisteredDefault(_mediator).ExecuteAsync(message);
            return;
        }

        Statuses status = user.Status;
        
        await _mediator.Send(new SendMessageCommand(
            Message: BotTextAnswers.DEFAULT,
            ChatId: message.Chat.Id,
            Status: status));
    }
}