using MediatR;
using Telegram.Bot.Types;

namespace TelegramBot.Telegram.ActionCommands;

public class LIKE_ActionCommand : ActionCommand
{
    public LIKE_ActionCommand(IMediator mediator) : base(mediator)
    {
    }

    public override Task Execute(Update update)
    {
        throw new NotImplementedException();
    }
}