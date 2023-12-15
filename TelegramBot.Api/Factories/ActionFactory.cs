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

        if (message.Photo is not null) action = new NewPictureExistAction(_mediator);
        if (message.MediaGroupId is not null) action = new BadPhotoDefaultAction(_mediator);
        else if (command == GETPICUTRE) action = new GetPictureExistAction(_mediator);
        else if (command == LIKE) action = new LikeExistAction(_mediator);
        else if (command == UPLOADPICTURE) action = new UploadPictureExistAction(_mediator);
        else if (command == GETBACK) action = new GetBackExistAction(_mediator);
        else if (command == STATISTIC) action = new StatisticExistAction(_mediator);
        else if (command == RULES) action = new RulesExistAction(_mediator);
        else if (command == GETSTART) action = new GetStartExistAction(_mediator);
        else if (command == START) action = new StartExistAction(_mediator);

        if (action is IExistAction existAction)
        {
            existAction = (IExistAction)action;
            existAction.ExecuteDefault += new DefaultAction(_mediator).ExecuteAsync;
            action = existAction;
        }
        
        return action;
    }
}