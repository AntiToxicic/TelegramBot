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
    private readonly ILikeRepository _likeRepository;

    public SendRandomPictureCommandHandler(IPictureSender pictureSender, IPictureRepository pictureRepository, IUserRepository userRepository, ILikeRepository likeRepository)
    {
        _pictureSender = pictureSender;
        _pictureRepository = pictureRepository;
        _userRepository = userRepository;
        _likeRepository = likeRepository;
    }

    public async Task Handle(SendRandomPictureCommand request, CancellationToken cancellationToken)
    {
        Picture picture = await _pictureRepository.GetRandomPictureInfoAsync();
        picture.Likes = await _likeRepository.GetLikes(picture);
        
        await _pictureSender.SendPictureAsync(
            picture, 
            request.ChatId,
            Statuses.WATCH);
        
        await _userRepository.SetPictureIdForRatingAsync(
            picId: picture.Id,
            userId: request.ChatId);
    }
}