using MediatR;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Requests.Commands;

namespace TelegramBot.ApplicationCore.Handlers.Commands;

public class SendFirstPictureCommandHandler : IRequestHandler<SendFirstPictureCommand>
{
    private readonly IPictureRepository _pictureRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPictureSender _pictureSender;

    public SendFirstPictureCommandHandler(IPictureRepository pictureRepository, IPictureSender pictureSender, IUserRepository userRepository)
    {
        _pictureRepository = pictureRepository;
        _pictureSender = pictureSender;
        _userRepository = userRepository;
    }

    public async Task Handle(SendFirstPictureCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.SetStatusAsync(request.Status, request.ChatId);
        Picture picture = await _pictureRepository.GetStartPictureInfoAsync();

        await _pictureSender.SendPictureAsync(
            picture, 
            request.ChatId,
            Statuses.WATCH);
        
        await _userRepository.SetPictureIdForRatingAsync(
            picId: picture.Id,
            userId: request.ChatId);
    }
}