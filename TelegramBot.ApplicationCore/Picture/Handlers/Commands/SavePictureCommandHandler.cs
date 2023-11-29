using MediatR;
using Telegram.Bot;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Requests.Commands;

namespace TelegramBot.ApplicationCore.Handlers.Commands;

public class SavePictureCommandHandler : IRequestHandler<SavePictureCommand>
{
    private readonly IPictureRepository _pictureRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPictureDownloader _pictureDownloader;
    
    public SavePictureCommandHandler(IPictureRepository pictureRepository, IPictureDownloader pictureDownloader, IUserRepository userRepository)
    {
        _pictureRepository = pictureRepository;
        _pictureDownloader = pictureDownloader;
        _userRepository = userRepository;
    }
    
    public async Task Handle(SavePictureCommand request, CancellationToken cancellationToken)
    {
        Picture picture = await _pictureDownloader.DownloadAsync(
            picId: request.PicId,
            caption: request.Caption,
            userId: request.UserId);
        
        await _pictureRepository.AddPictureInfoAsync(picture);
        await _userRepository.IncreaseUserUploadsCountAsync(request.UserId);
    }
}