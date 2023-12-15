using MediatR;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Requests.Commands;

namespace TelegramBot.ApplicationCore.Handlers.Commands;

public class IncreaseRatingCommandHandler : IRequestHandler<IncreasePictureRatingCommand>
{
    private readonly IPictureRepository _pictureRepository;
    private readonly IUserRepository _userRepository;
    private readonly ILikeRepository _likeRepository;

    public IncreaseRatingCommandHandler(IPictureRepository pictureRepository, IUserRepository userRepository, ILikeRepository likeRepository)
    {
        _pictureRepository = pictureRepository;
        _userRepository = userRepository;
        _likeRepository = likeRepository;
    }

    public async Task Handle(IncreasePictureRatingCommand request, CancellationToken cancellationToken)
    {
        var userRater = await _userRepository.GetUserAsync(request.UserId);
        var pictureRated = await _pictureRepository.GetPicture(userRater.PictureIdForRate);
        
        await _likeRepository.AddLikeAsync(userRater, pictureRated);
    }
}