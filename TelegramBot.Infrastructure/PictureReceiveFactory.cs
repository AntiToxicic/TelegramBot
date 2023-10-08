using Microsoft.Extensions.DependencyInjection;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.Infrastructure.PictureStorage;

namespace TelegramBot.Infrastructure;

public class PictureReceiveFactory : IPictureReceiveFactory
{
    private IServiceProvider _serviceProvider;

    public PictureReceiveFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IPictureReceive Process()
    {
        return _serviceProvider.GetRequiredService<PictureReceive>();
    }
}