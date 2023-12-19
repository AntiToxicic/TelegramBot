using MediatR;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Exceptions;
using TelegramBot.ApplicationCore.Interfaces;

namespace TelegramBot.ApplicationCore.Commands;

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
        var user = await _userRepository.GetOrCreate(command.ChatId, command.Name, cancellationToken);

        if (!user.LastReceivedPictureInfoId.HasValue)
            throw new Exception();

        var like = new Like(user.Id, user.LastReceivedPictureInfoId.Value);

        await _likeRepository.AddIfNotExistAsync(like, cancellationToken);

        var randomPictureInfo = await _pictureRepository.Random(cancellationToken);

        if (randomPictureInfo == null)
            throw new Exception();

        await _pictureService.Send(user.ChatId, randomPictureInfo, cancellationToken);

        await _userRepository.UpdateLastReceivedPictureInfoId(user.Id, randomPictureInfo.Id, cancellationToken);
    }
}
