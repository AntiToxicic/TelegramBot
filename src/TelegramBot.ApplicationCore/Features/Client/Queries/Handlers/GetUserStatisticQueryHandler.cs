using MediatR;
using TelegramBot.ApplicationCore.Features.Queries.Requests;

namespace TelegramBot.ApplicationCore.Features.Queries.Handlers;

public class GetUserStatisticQueryHandler : IRequestHandler<GetUserStatisticQuery>
{
    public async Task Handle(GetUserStatisticQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
