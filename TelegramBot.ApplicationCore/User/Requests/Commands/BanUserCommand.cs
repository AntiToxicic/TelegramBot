using MediatR;
using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Requests.Commands;

public record BanUserCommand(long chatId) : IRequest<User>;