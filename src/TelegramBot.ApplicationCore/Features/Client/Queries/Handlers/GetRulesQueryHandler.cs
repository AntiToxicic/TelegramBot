using MediatR;
using TelegramBot.ApplicationCore.Features.Queries.Requests;

namespace TelegramBot.ApplicationCore.Features.Queries.Handlers;

public class GetRulesQueryHandler : IRequestHandler<GetRulesQuery>
{
    public async Task Handle(GetRulesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
