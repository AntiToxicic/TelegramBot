using MediatR;
using TelegramBot.ApplicationCore.Interfaces;

namespace TelegramBot.ApplicationCore.Commands;

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
        var user = await _userRepository.GetOrCreate(command.ChatId, command.Name, cancellationToken);

        var randomPictureInfo = await _pictureRepository.Random(cancellationToken);

        if (randomPictureInfo == null)
        {
            throw new Exception();
        }

        await _pictureService.Send(user.ChatId, randomPictureInfo, cancellationToken);

        await _userRepository.UpdateLastReceivedPictureInfoId(user.Id, randomPictureInfo.Id, cancellationToken);
    }
}
