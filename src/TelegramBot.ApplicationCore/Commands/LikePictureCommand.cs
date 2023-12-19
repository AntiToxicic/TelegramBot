using MediatR;

namespace TelegramBot.ApplicationCore.Commands;

public record LikePictureCommand(long ChatId, string Name) : IRequest;
