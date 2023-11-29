using MediatR;

namespace TelegramBot.ApplicationCore.Message.Requests.Commands;

public record SendUserStatisticCommand(string Message, long ChatId, Statuses Status) : IRequest;