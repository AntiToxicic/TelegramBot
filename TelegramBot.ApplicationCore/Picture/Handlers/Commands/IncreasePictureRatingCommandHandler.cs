using MediatR;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Requests.Commands;

namespace TelegramBot.ApplicationCore.Handlers.Commands;

public class IncreasePictureRatingCommandHandler : IRequestHandler<IncreasePictureRatingCommand>
{
    private readonly IPictureRepository _pictureRepository;

    public IncreasePictureRatingCommandHandler(IPictureRepository pictureRepository)
    {
        _pictureRepository = pictureRepository;
    }

    public async Task Handle(IncreasePictureRatingCommand request, CancellationToken cancellationToken)
    {
        await _pictureRepository.IncreasePositiveRatingAsync(request.UserId);
    }
}