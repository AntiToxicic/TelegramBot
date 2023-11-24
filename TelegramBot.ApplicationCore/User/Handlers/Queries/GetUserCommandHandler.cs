using MediatR;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Requests.Queries;

namespace TelegramBot.ApplicationCore.Handlers.Queries;

public class GetUserCommandHandler : IRequestHandler<GetUserCommand, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(GetUserCommand request, CancellationToken cancellationToken) =>
        await _userRepository.GetUserAsync(request.ChatId);
}