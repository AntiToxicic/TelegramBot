using MediatR;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Requests.Commands;

namespace TelegramBot.ApplicationCore.Handlers.Commands;

public class SaveUserInfoCommandHandler : IRequestHandler<SaveUserInfoCommand>
{
    private readonly IUserInfoReceiving _userInfoReceiving;
    private readonly IUserRepository _userRepository;

    public SaveUserInfoCommandHandler(IUserInfoReceiving userInfoReceiving, IUserRepository userRepository)
    {
        _userInfoReceiving = userInfoReceiving;
        _userRepository = userRepository;
    }

    public async Task Handle(SaveUserInfoCommand request, CancellationToken cancellationToken)
    {
        User user = await _userInfoReceiving.GetUserInfoAsync(request.UserId);

        await _userRepository.AddUserAsync(user);
    }
} 