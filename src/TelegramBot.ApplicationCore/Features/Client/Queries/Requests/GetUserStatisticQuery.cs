using MediatR;

namespace TelegramBot.ApplicationCore.Features.Queries.Requests;

public record GetUserStatisticQuery(long ChatId) : IRequest;

