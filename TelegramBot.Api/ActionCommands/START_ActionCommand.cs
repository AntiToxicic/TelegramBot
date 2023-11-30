using MediatR;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Message.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Queries;
using static TelegramBot.Telegram.TelegramCommands;

namespace TelegramBot.Telegram.ActionCommands;

public class START_ActionCommand : ActionCommand
{
    public START_ActionCommand(IMediator mediator, Statuses status, string command) : base(mediator, status, command)
    {
    }

    public override async Task Execute(Update update)
    {
        var msg = update.Message!;
        var command = msg.Text;
        
        if (command != START) return;
        
        Statuses status = (await Mediator.Send(new GetUserCommand(msg.Chat.Id))).Status;

        
        await Mediator.Send(new SaveUserInfoCommand(msg.Chat.Id));
        await Mediator.Send(new SendMessageCommand(
            Message: BotTextAnswers.START,
            ChatId: msg.Chat.Id,
            Status: Statuses.START));
    }
}