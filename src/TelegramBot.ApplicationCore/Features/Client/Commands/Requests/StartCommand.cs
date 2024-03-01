using MediatR;

namespace TelegramBot.ApplicationCore.Features.Commands;

public record StartCommand(long ChatId, string? UserName) : IRequest;
