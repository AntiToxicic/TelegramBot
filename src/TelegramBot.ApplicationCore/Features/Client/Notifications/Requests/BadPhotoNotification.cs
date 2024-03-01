using MediatR;

namespace TelegramBot.ApplicationCore.Features.Notifications.Requests;

public record BadPhotoNotification(long ChatId) : INotification;

