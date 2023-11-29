using MediatR;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Requests.Commands;

namespace TelegramBot.ApplicationCore.Handlers.Commands;

public class IncreasePictureRatingCommandHandler : IRequestHandler<IncreasePictureRatingCommand>
{
    private readonly IPictureRepository _pictureRepository;
    private readonly IUserRepository _userRepository;

    public IncreasePictureRatingCommandHandler(IPictureRepository pictureRepository, IUserRepository userRepository)
    {
        _pictureRepository = pictureRepository;
        _userRepository = userRepository;
    }

    public async Task Handle(IncreasePictureRatingCommand request, CancellationToken cancellationToken)
    {
        await _pictureRepository.IncreasePositiveRatingAsync(request.UserId);
        await _userRepository.IncreaseUserRatingAsync(request.UserId);
    }
}