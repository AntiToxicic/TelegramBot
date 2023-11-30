using MediatR;
using Telegram.Bot.Types;

namespace TelegramBot.Telegram.ActionCommands;

public class GETSTART_ActionCommand : ActionCommand
{
    public GETSTART_ActionCommand(IMediator mediator) : base(mediator)
    {
    }

    public override Task Execute(Update update)
    {
        throw new NotImplementedException();
    }
}