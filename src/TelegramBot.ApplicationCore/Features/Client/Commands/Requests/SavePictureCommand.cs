using MediatR;

namespace TelegramBot.ApplicationCore.Features.Commands;

public record SavePictureCommand(long ChatId, string PicId, string Caption) : IRequest;
