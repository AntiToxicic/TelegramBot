using MediatR;

namespace TelegramBot.ApplicationCore.Features.Commands;

public class GetStartCommandHandler : IRequestHandler<GetStartCommand>
{
    public async Task Handle(GetStartCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
