using MediatR;

namespace TelegramBot.ApplicationCore.Requests.Commands;

public record SavePictureCommand(string PicId, string? Caption, long UserId) : IRequest;
