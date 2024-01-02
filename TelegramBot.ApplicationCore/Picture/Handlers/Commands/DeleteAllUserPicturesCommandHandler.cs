using MediatR;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Requests.Commands;

namespace TelegramBot.ApplicationCore.Handlers.Commands;

public class DeleteAllUserPicturesCommandHandler : IRequestHandler<DeleteAllUserPicturesCommand>
{
    private readonly IPictureRepository _pictureRepository;

    public DeleteAllUserPicturesCommandHandler(IPictureRepository pictureRepository)
    {
        _pictureRepository = pictureRepository;
    }

    public async Task Handle(DeleteAllUserPicturesCommand request, CancellationToken cancellationToken)
    {
        await _pictureRepository.DeleteAllUserPictures(request.UserId);
    }
}