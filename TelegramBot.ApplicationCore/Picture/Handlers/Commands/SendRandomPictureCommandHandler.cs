using MediatR;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Requests.Commands;

namespace TelegramBot.ApplicationCore.Handlers.Commands;

public class SendRandomPictureCommandHandler : IRequestHandler<SendRandomPictureCommand>
{
    private readonly IPictureSender _pictureSender;
    private readonly IPictureRepository _pictureRepository;

    public SendRandomPictureCommandHandler(IPictureSender pictureSender, IPictureRepository pictureRepository)
    {
        _pictureSender = pictureSender;
        _pictureRepository = pictureRepository;
    }

    public async Task Handle(SendRandomPictureCommand request, CancellationToken cancellationToken)
    {
        
        Console.WriteLine("Get Random Picture start");
        Picture? picture = await _pictureRepository.GetRandomPictureInfoAsync();
        Console.WriteLine("Get Random Picture is work");
        await _pictureSender.SendPictureAsync(
            picture, 
            request.chatId,
            Statuses.WATCH);
    }
}