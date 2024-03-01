using MediatR;

namespace TelegramBot.ApplicationCore.Features.Notifications.Requests;

public record NewPictureNotification(uint PicId) : INotification;
