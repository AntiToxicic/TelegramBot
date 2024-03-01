using MediatR;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Enums;
using TelegramBot.ApplicationCore.Exceptions;
using TelegramBot.ApplicationCore.Interfaces;

namespace TelegramBot.ApplicationCore.Features.Commands;

public class SavePictureCommandHandler : IRequestHandler<SavePictureCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IPictureInfoRepository _pictureRepository;
    private readonly IPictureService _pictureService;

    public SavePictureCommandHandler(
        IUserRepository userRepository,
        IPictureInfoRepository pictureRepository,
        IPictureService downloadPictureService)
    {
        _userRepository = userRepository;
        _pictureRepository = pictureRepository;
        _pictureService = downloadPictureService;
    }

    public async Task Handle(SavePictureCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserAsync(command.ChatId, cancellationToken);
        
        if (user is null)
            throw new UserNotFoundException();

        if (user.Status is not UserStatus.AwaitPicture)
            throw new InvalidUserStatusException();

        var path = await _pictureService.DownloadAsync(user.ChatId, command.PicId, cancellationToken);

        var pictureInfo = new Picture(user.Id, path, command.Caption);

        await _pictureRepository.AddAsync(pictureInfo, cancellationToken);
    }
}
