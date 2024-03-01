using MediatR;

namespace TelegramBot.ApplicationCore.Features.Notifications.Requests;

public record WrongCommandNotification(long ChatId) : INotification;
