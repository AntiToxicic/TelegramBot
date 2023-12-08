using MediatR;
using Telegram.Bot.Types;
using TelegramBot.Telegram.Actions;
using TelegramBot.Telegram.Interfaces;
using static TelegramBot.Telegram.TelegramCommands;

namespace TelegramBot.Telegram.Factories;

public class ActionFactory : IActionFactory
{
    private readonly IMediator _mediator;

    public ActionFactory(IMediator mediator)
    {
        _mediator = mediator;
    }

    public IAction GetAction(Message message)
    {
        var command = message.Text;
        IAction action = new DefaultAction(_mediator);

        if (message.Photo is not null) action = new NewPictureAction(_mediator);
        
        if (command == GETPICUTRE) action = new GetPictureAction(_mediator);
        if (command == LIKE) action = new LikeAction(_mediator);
        if (command == UPLOADPICTURE) action = new UploadPictureAction(_mediator);
        if (command == GETBACK) action = new GetBackAction(_mediator);
        if (command == STATISTIC) action = new StatisticAction(_mediator);
        if (command == RULES) action = new RulesAction(_mediator);
        if (command == GETSTART) action = new GetStartAction(_mediator);
        if (command == START) action = new StartAction(_mediator);

        action.ExecuteDefault += new DefaultAction(_mediator).ExecuteAsync;
        
        return action;
    }
}