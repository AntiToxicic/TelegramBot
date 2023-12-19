using MediatR;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Enums;
using TelegramBot.ApplicationCore.Exceptions;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Resources;

namespace TelegramBot.ApplicationCore.Commands;

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
        var user = await _userRepository.GetOrCreate(command.ChatId, command.Name, cancellationToken);

        var path = await _pictureService.Download(command.PicId, cancellationToken);

        var pictureInfo = new PictureInfo(user.Id, path, command.Caption);

        await _pictureRepository.AddAsync(pictureInfo, cancellationToken);
    }
}
