using MediatR;
using TelegramBot.ApplicationCore.Features.Commands;
using TelegramBot.ApplicationCore.Features.Notifications.Handlers;
using TelegramBot.ApplicationCore.Features.Notifications.Requests;
using TelegramBot.ApplicationCore.Features.Queries.Handlers;
using TelegramBot.ApplicationCore.Features.Queries.Requests;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.Infrastructure.Repositories;
using TelegramBot.Infrastructure.Services;

namespace TelegramBot.Telegram.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection sp) =>
        sp
            .AddScoped<ILikeRepository, LikeRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IPictureInfoRepository, PictureInfoRepository>();

    public static IServiceCollection AddServices(this IServiceCollection sp) =>
        sp
            .AddScoped<IPictureService, PictureService>()
            
            .AddScoped<IRequestHandler<LikePictureCommand>, LikePictureCommandHandler>()
            .AddScoped<IRequestHandler<SavePictureCommand>, SavePictureCommandHandler>()
            .AddScoped<IRequestHandler<BackToWatchCommand>, BackToWatchCommandHandler>()
            .AddScoped<IRequestHandler<GetRulesQuery>, GetRulesQueryHandler>()
            .AddScoped<IRequestHandler<GetStartCommand>, GetStartCommandHandler>()
            .AddScoped<IRequestHandler<GetUserStatisticQuery>, GetUserStatisticQueryHandler>()
            .AddScoped<IRequestHandler<StartCommand>, StartCommandHandler>()
            .AddScoped<INotificationHandler<WrongCommandNotification>, WrongCommandNotificationHandler>()
            .AddScoped<INotificationHandler<NewPictureNotification>, NewPictureNotificationHandler>()
            .AddScoped<INotificationHandler<BadPhotoNotification>, BadPhotoNotificationHandler>();
}
