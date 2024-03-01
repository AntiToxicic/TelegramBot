using MediatR;
using TelegramBot.ApplicationCore.Features.Notifications.Requests;

namespace TelegramBot.ApplicationCore.Features.Notifications.Handlers;

public class NewPictureNotificationHandler : INotificationHandler<NewPictureNotification>
{
    public async Task Handle(NewPictureNotification notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
