using MediatR;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Requests.Commands;

namespace TelegramBot.ApplicationCore.Handlers.Commands;

public class IncreaseRatingCommandHandler : IRequestHandler<IncreasePictureRatingCommand>
{
    private readonly IPictureRepository _pictureRepository;
    private readonly IUserRepository _userRepository;

    public IncreaseRatingCommandHandler(IPictureRepository pictureRepository, IUserRepository userRepository)
    {
        _pictureRepository = pictureRepository;
        _userRepository = userRepository;
    }

    public async Task Handle(IncreasePictureRatingCommand request, CancellationToken cancellationToken)
    {
        var userRater = await _userRepository.GetUserAsync(request.UserId);
        var pictureRated = await _pictureRepository.GetPicture(userRater.PictureIdForRate);
        var userRated = await _userRepository.GetUserAsync(pictureRated.UserId);
        
        await _pictureRepository.IncreasePictureRatingAsync(pictureRated.Id);
        await _userRepository.IncreaseUserRatingAsync(userRated.Id);
        await _pictureRepository.AddUserLikedAsync(request.UserId, pictureRated.Id);
    }
}