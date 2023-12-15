using MediatR;

namespace TelegramBot.ApplicationCore.Requests.Commands;

public record AddLikeCommand(long UserId) : IRequest;