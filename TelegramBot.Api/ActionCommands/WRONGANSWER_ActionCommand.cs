using MediatR;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Message.Requests.Commands;

namespace TelegramBot.Telegram.ActionCommands;

public class WRONGANSWER_ActionCommand : ActionCommand
{
    public WRONGANSWER_ActionCommand(IMediator mediator, Statuses status, string? command = null) : base(mediator, status, command!)
    {
    }

    public override async Task Execute(Update update)
    {
        var msg = update.Message!;
        
        await Mediator.Send(new SendMessageCommand(
            Message: BotTextAnswers.WRONGANSWER,
            ChatId: msg.Chat.Id,
            Status: Status));
    }
}