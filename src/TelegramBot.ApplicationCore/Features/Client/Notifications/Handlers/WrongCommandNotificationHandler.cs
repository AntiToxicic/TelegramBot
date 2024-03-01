using MediatR;
using TelegramBot.ApplicationCore.Features.Notifications.Requests;

namespace TelegramBot.ApplicationCore.Features.Notifications.Handlers;

public class WrongCommandNotificationHandler : INotificationHandler<WrongCommandNotification>
{
    public async Task Handle(WrongCommandNotification notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
