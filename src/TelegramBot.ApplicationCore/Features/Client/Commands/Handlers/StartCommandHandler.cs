using MediatR;

namespace TelegramBot.ApplicationCore.Features.Commands;

public class StartCommandHandler : IRequestHandler<StartCommand>
{
    public async Task Handle(StartCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
