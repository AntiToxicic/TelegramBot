using MediatR;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Requests.Queries;

namespace TelegramBot.ApplicationCore.Handlers.Queries;

public class GetUserStatusCommandHandler : IRequestHandler<GetUserStatusCommand, Statuses>
{
    private readonly IUserRepository _userRepository;

    public GetUserStatusCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Statuses> Handle(GetUserStatusCommand request, CancellationToken cancellationToken) =>
        await _userRepository.GetStatusAsync(request.ChatId);
}