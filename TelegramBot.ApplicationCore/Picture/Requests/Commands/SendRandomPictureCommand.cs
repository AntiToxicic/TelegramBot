using MediatR;
using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Requests.Commands;

public record SendRandomPictureCommand(long ChatId) : IRequest;