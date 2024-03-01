using MediatR;

namespace TelegramBot.ApplicationCore.Features.Commands;

public record SendRandomPictureCommand(long ChatId) : IRequest;
