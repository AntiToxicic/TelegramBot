using MediatR;
using TelegramBot.ApplicationCore.Entities;


namespace TelegramBot.ApplicationCore.Requests.Queries;

public record GetUserCommand(long ChatId) : IRequest<User?>;