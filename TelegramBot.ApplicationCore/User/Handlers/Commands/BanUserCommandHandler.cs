using MediatR;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Requests.Commands;

namespace TelegramBot.ApplicationCore.Handlers.Commands;

public class BanUserCommandHandler : IRequestHandler<BanUserCommand, User>
{
    private readonly IPictureRepository _pictureRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMessageSender _messageSender;

    public BanUserCommandHandler(IPictureRepository pictureRepository, IUserRepository userRepository, IMessageSender messageSender)
    {
        _pictureRepository = pictureRepository;
        _userRepository = userRepository;
        _messageSender = messageSender;
    }

    public async Task<User> Handle(BanUserCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.BanUserAsync(request.chatId);
    }
}