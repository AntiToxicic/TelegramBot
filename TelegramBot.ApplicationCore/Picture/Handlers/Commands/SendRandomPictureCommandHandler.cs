using MediatR;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Requests.Commands;

namespace TelegramBot.ApplicationCore.Handlers.Commands;

public class SendRandomPictureCommandHandler : IRequestHandler<SendRandomPictureCommand>
{
    private readonly IPictureSender _pictureSender;
    private readonly IPictureRepository _pictureRepository;
    private readonly IUserRepository _userRepository;

    public SendRandomPictureCommandHandler(IPictureSender pictureSender, IPictureRepository pictureRepository, IUserRepository userRepository)
    {
        _pictureSender = pictureSender;
        _pictureRepository = pictureRepository;
        _userRepository = userRepository;
    }

    public async Task Handle(SendRandomPictureCommand request, CancellationToken cancellationToken)
    {
        Picture picture = await _pictureRepository.GetRandomPictureInfoAsync();
        
        await _pictureSender.SendPictureAsync(
            picture, 
            request.ChatId,
            Statuses.WATCH);
        
        await _userRepository.SetPictureIdForRatingAsync(
            picId: picture.Id,
            userId: request.ChatId);
    }
}