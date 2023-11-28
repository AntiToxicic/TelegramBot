using MediatR;

namespace TelegramBot.ApplicationCore.Requests.Commands;

public record IncreasePictureRatingCommand(long UserId) : IRequest;