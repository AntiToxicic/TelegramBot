using MediatR;

namespace TelegramBot.ApplicationCore.Features.Commands;

public record BackToWatchCommand(long ChatId) : IRequest;

