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
        if (message.MediaGroupId is not null) action = new BadPhotoDefaultAction(_mediator);
        else if (command == GETPICUTRE) action = new GetPictureAction(_mediator);
        else if (command == LIKE) action = new LikeAction(_mediator);
        else if (command == UPLOADPICTURE) action = new UploadPictureAction(_mediator);
        else if (command == GETBACK) action = new GetBackAction(_mediator);
        else if (command == STATISTIC) action = new StatisticAction(_mediator);
        else if (command == RULES) action = new RulesAction(_mediator);
        else if (command == GETSTART) action = new GetStartAction(_mediator);
        else if (command == START) action = new StartAction(_mediator);

        if (action is IExistAction existAction)
        {
            existAction = (IExistAction)action;
            existAction.ExecuteDefault += new DefaultAction(_mediator).ExecuteAsync;
            existAction.ExecuteNotRegisteredDefault += new NotRegisteredDefault(_mediator).ExecuteAsync;
            action = existAction;
        }
        
        return action;
    }
}