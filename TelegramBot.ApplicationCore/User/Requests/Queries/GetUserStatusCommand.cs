using MediatR;

namespace TelegramBot.ApplicationCore.Requests.Queries;

public record GetUserStatusCommand(long ChatId) : IRequest<Statuses>;