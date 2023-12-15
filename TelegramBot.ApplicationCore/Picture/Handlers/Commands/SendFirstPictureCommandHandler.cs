using MediatR;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Requests.Commands;

namespace TelegramBot.ApplicationCore.Handlers.Commands;

public class SendFirstPictureCommandHandler : IRequestHandler<SendFirstPictureCommand>
{
    private readonly IPictureRepository _pictureRepository;
    private readonly IUserRepository _userRepository;
    private readonly ILikeRepository _likeRepository;
    private readonly IPictureSender _pictureSender;

    public SendFirstPictureCommandHandler(IPictureRepository pictureRepository, IPictureSender pictureSender, IUserRepository userRepository, ILikeRepository likeRepository)
    {
        _pictureRepository = pictureRepository;
        _pictureSender = pictureSender;
        _userRepository = userRepository;
        _likeRepository = likeRepository;
    }

    public async Task Handle(SendFirstPictureCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.SetStatusAsync(request.Status, request.ChatId);
        Picture picture = await _pictureRepository.GetStartPictureInfoAsync();
        picture.Likes = await _likeRepository.GetLikes(picture);

        await _userRepository.SetPictureIdForRatingAsync(
            picId: picture.Id,
            userId: request.ChatId);
        
        await _pictureSender.SendPictureAsync(
            picture, 
            request.ChatId,
            Statuses.WATCH);
    }
}