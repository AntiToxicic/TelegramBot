using MediatR;
using Telegram.Bot.Types;

namespace TelegramBot.Telegram.ActionCommands;

public class UPLOADPICTURE_ActionCommand : ActionCommand
{
    public UPLOADPICTURE_ActionCommand(IMediator mediator) : base(mediator)
    {
    }

    public override Task Execute(Update update)
    {
        throw new NotImplementedException();
    }
}