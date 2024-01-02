using MediatR;

namespace TelegramBot.ApplicationCore.Requests.Commands;

public record DeleteAllUserPicturesCommand(long UserId) : IRequest;