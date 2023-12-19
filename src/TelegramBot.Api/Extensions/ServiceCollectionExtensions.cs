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
            .AddScoped<IPictureService, PictureService>();
}
