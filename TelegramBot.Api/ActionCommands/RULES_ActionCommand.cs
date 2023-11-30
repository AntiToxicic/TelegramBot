using MediatR;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Message.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Queries;
using static TelegramBot.Telegram.TelegramCommands;


namespace TelegramBot.Telegram.ActionCommands;

public class RULES_ActionCommand : ActionCommand
{
    public RULES_ActionCommand(IMediator mediator, Statuses status, string command) : base(mediator, status, command)
    {
    }

    public override async Task Execute(Update update)
    {
        var msg = update.Message!;
        
        await Mediator.Send(new SendMessageCommand(
            Message: BotTextAnswers.RULES,
            ChatId: msg.Chat.Id,
            Status: Status));
    }
}