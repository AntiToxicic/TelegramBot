using MediatR;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Message.Requests.Commands;

namespace TelegramBot.ApplicationCore.Message.Handlers.Commands;

public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand>
{
    private readonly IMessageSender _messageSender;
    private readonly IUserRepository _userRepository;

    public SendMessageCommandHandler(IMessageSender messageSender, IUserRepository userRepository)
    {
        _messageSender = messageSender;
        _userRepository = userRepository;
    }

    public async Task Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.SetStatusAsync(request.Status, request.ChatId);
        
        await _messageSender.SendMessageAsync(
           request.Message,
           request.ChatId,
           request.Status);
    }
}