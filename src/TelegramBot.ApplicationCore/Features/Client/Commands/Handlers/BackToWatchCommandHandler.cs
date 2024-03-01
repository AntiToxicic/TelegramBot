using MediatR;

namespace TelegramBot.ApplicationCore.Features.Commands;

public class BackToWatchCommandHandler : IRequestHandler<BackToWatchCommand>
{
    public async Task Handle(BackToWatchCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
