using MediatR;

namespace TelegramBot.ApplicationCore.Commands;

public record SendRandomPictureCommand(long ChatId, string Name) : IRequest;
