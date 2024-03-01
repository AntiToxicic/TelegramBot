using MediatR;

namespace TelegramBot.ApplicationCore.Features.Queries.Requests;

public record GetRulesQuery(long ChatId) : IRequest;
