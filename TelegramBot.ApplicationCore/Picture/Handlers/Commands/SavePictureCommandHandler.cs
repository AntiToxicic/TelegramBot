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
    private readonly IPictureSender _pictureSender;
    
    public SavePictureCommandHandler(IPictureRepository pictureRepository, IPictureDownloader pictureDownloader, IUserRepository userRepository, IPictureSender pictureSender)
    {
        _pictureRepository = pictureRepository;
        _pictureDownloader = pictureDownloader;
        _userRepository = userRepository;
        _pictureSender = pictureSender;
    }
    
    public async Task Handle(SavePictureCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserAsync(request.UserId);
        
        Picture picture = await _pictureDownloader.DownloadAsync(
            picId: request.PicId,
            caption: request.Caption,
            user: user);
        
        await _pictureRepository.AddPictureInfoAsync(picture);
        
        picture.Caption += $"\n\nПользователь \"{user.Name}\" добавил картинку";
        
        await _pictureSender.SendPictureAsync(
            picture, 
            -1002001774648,
            Statuses.WATCH, 3);
    }
}