using MediatR;
using Telegram.Bot.Types;

namespace TelegramBot.Telegram.ActionCommands;

public class GETPICTURE_ActionCommand : ActionCommand
{
    public GETPICTURE_ActionCommand(IMediator mediator) : base(mediator)
    {
    }

    public override Task Execute(Update update)
    {
        throw new NotImplementedException();
    }
}