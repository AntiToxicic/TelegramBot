using MediatR;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Requests.Commands;

namespace TelegramBot.ApplicationCore.Handlers.Commands;

public class DeletePictureCommandHandler : IRequestHandler<DeletePictureCommand, User>
{
    private readonly IPictureRepository _pictureRepository;

    public DeletePictureCommandHandler(IPictureRepository pictureRepository)
    {
        _pictureRepository = pictureRepository;
    }

    public async Task<User> Handle(DeletePictureCommand request, CancellationToken cancellationToken)
    {
        return await _pictureRepository.DeleteUserPicture(request.UserId);
    }
}