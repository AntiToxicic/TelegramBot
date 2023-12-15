using MediatR;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Message.Requests.Commands;

namespace TelegramBot.ApplicationCore.Message.Handlers.Commands;

public class SendUserStatisticCommandHandler : IRequestHandler<SendUserStatisticCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IPictureRepository _pictureRepository;
    private readonly ILikeRepository _likeRepository;
    private readonly IMessageSender _messageSender;

    public SendUserStatisticCommandHandler(IUserRepository userRepository, IMessageSender messageSender, IPictureRepository pictureRepository, ILikeRepository likeRepository)
    {
        _userRepository = userRepository;
        _messageSender = messageSender;
        _pictureRepository = pictureRepository;
        _likeRepository = likeRepository;
    }

    public async Task Handle(SendUserStatisticCommand request, CancellationToken cancellationToken)
    {
        User user = (await _userRepository.GetUserAsync(request.ChatId))!;
        var picCount = await _pictureRepository.GetPictureCountOfUser(request.ChatId);
        var rating = await _likeRepository.GetLikesCountOfUserAsync(user);
        
        var message = String.Format(request.Message, rating, picCount);
        
        await _userRepository.SetStatusAsync(request.Status, request.ChatId);
        
        await _messageSender.SendMessageAsync(
            message: message,
            chatId: request.ChatId,
            status: request.Status);
    }
}