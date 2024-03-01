using MediatR;

namespace TelegramBot.ApplicationCore.Features.Commands;

public record GetStartCommand(long ChatId) : IRequest;
