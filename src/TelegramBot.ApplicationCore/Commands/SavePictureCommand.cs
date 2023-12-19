using MediatR;

namespace TelegramBot.ApplicationCore.Commands;

public record SavePictureCommand(long ChatId, string Name, string PicId, string Caption) : IRequest;
