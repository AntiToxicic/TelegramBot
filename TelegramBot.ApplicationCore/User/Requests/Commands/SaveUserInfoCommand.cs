using MediatR;
using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Requests.Commands;

public record SaveUserInfoCommand(long UserId) : IRequest;