using MediatR;

namespace TelegramBot.ApplicationCore.Message.Requests.Commands;

public record SendMessageCommand(string Message, long ChatId, Statuses Status) : IRequest;