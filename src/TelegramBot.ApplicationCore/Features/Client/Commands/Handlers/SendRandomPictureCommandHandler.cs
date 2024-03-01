using MediatR;
using TelegramBot.ApplicationCore.Enums;
using TelegramBot.ApplicationCore.Exceptions;
using TelegramBot.ApplicationCore.Interfaces;

namespace TelegramBot.ApplicationCore.Features.Commands;

public class SendRandomPictureCommandHandler : IRequestHandler<SendRandomPictureCommand>
{
    private readonly IUserRepository _userRepository;

    private readonly IPictureInfoRepository _pictureRepository;

    private readonly IPictureService _pictureService;

    public SendRandomPictureCommandHandler(
        IUserRepository userRepository,
        IPictureInfoRepository pictureRepository,
        IPictureService pictureService)
    {
        _userRepository = userRepository;
        _pictureRepository = pictureRepository;
        _pictureService = pictureService;
    }

    public async Task Handle(SendRandomPictureCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserAsync(command.ChatId, cancellationToken);
        
        if (user is null)
            throw new UserNotFoundException();

        if (user.Status is not UserStatus.Watch)
            throw new InvalidUserStatusException();

        if (user.LastReceivedPictureInfoId.HasValue is not true)
            throw new Exception();

        var randomPictureInfo = await _pictureRepository.GetRandomPictureAsync(cancellationToken);

        if (randomPictureInfo == null)
            throw new Exception();
        
        await _pictureService.SendPictureAsync(user.ChatId, randomPictureInfo, cancellationToken);

        await _userRepository.UpdateLastReceivedPictureInfoIdAsync(user, randomPictureInfo.Id, cancellationToken);
    }
}
