using MediatR;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Enums;
using TelegramBot.ApplicationCore.Exceptions;
using TelegramBot.ApplicationCore.Interfaces;

namespace TelegramBot.ApplicationCore.Features.Commands;

public class LikePictureCommandHandler : IRequestHandler<LikePictureCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IPictureInfoRepository _pictureRepository;
    private readonly ILikeRepository _likeRepository;
    private readonly IPictureService _pictureService;

    public LikePictureCommandHandler(
        IUserRepository userRepository,
        IPictureInfoRepository pictureRepository,
        ILikeRepository likeRepository,
        IPictureService pictureService)
    {
        _userRepository = userRepository;
        _pictureRepository = pictureRepository;
        _likeRepository = likeRepository;
        _pictureService = pictureService;
    }

    public async Task Handle(LikePictureCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserAsync(command.ChatId, cancellationToken);

        if (user is null)
            throw new UserNotFoundException();

        if (user.Status is not UserStatus.Watch)
            throw new InvalidUserStatusException();

        if (user.LastReceivedPictureInfoId.HasValue is not true)
            throw new Exception();

        var like = new Like(user.Id, user.LastReceivedPictureInfoId.Value);

        try
        {
            await _likeRepository.AddIfNotExistAsync(like, cancellationToken);
        }
        catch (LikeAlreadyExistExeption e)
        {
            throw new LikeAlreadyExistExeption();
        }

        var randomPictureInfo = await _pictureRepository.GetRandomPictureAsync(cancellationToken);

        if (randomPictureInfo is null)
            throw new Exception();

        await _userRepository.UpdateLastReceivedPictureInfoIdAsync(user, randomPictureInfo.Id, cancellationToken);
        
        await _pictureService.SendPictureAsync(user.ChatId, randomPictureInfo, cancellationToken);
    }
}
