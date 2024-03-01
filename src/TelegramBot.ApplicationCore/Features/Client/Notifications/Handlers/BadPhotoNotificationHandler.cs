using MediatR;
using TelegramBot.ApplicationCore.Features.Notifications.Requests;

namespace TelegramBot.ApplicationCore.Features.Notifications.Handlers;

public class BadPhotoNotificationHandler : INotificationHandler<BadPhotoNotification>
{
    public async Task Handle(BadPhotoNotification notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
