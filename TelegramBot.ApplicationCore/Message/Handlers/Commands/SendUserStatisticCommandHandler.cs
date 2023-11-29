using MediatR;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Message.Requests.Commands;

namespace TelegramBot.ApplicationCore.Message.Handlers.Commands;

public class SendUserStatisticCommandHandler : IRequestHandler<SendUserStatisticCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IMessageSender _messageSender;

    public SendUserStatisticCommandHandler(IUserRepository userRepository, IMessageSender messageSender)
    {
        _userRepository = userRepository;
        _messageSender = messageSender;
    }

    public async Task Handle(SendUserStatisticCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.SetStatusAsync(request.Status, request.ChatId);
        User user = await _userRepository.GetUserAsync(request.ChatId);

        Console.WriteLine(request.Message);
        var message = String.Format(request.Message, user.Likes, user.Uploads);
        
        await _messageSender.SendMessage(
            message: message,
            chatId: request.ChatId,
            status: request.Status);
    }
}