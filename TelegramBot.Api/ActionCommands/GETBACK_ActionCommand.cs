using MediatR;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore;

namespace TelegramBot.Telegram.ActionCommands;

public class GETBACK_ActionCommand : ActionCommand
{
    public GETBACK_ActionCommand(IMediator mediator, Statuses status, string command) : base(mediator, status, command)
    {
    }

    public override Task Execute(Update update)
    {
        throw new NotImplementedException();
    }
}