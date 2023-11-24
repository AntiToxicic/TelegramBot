using MediatR;

namespace TelegramBot.ApplicationCore.Requests.Commands;

public record SendFirstPictureCommand(long ChatId, Statuses Status) : IRequest;