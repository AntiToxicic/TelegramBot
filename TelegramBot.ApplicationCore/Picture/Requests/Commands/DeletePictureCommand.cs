using MediatR;
using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Requests.Commands;

public record DeletePictureCommand(long UserId) : IRequest<User>;