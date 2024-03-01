using MediatR;

namespace TelegramBot.ApplicationCore.Features.Commands;

public record LikePictureCommand(long ChatId) : IRequest;
