using TelegramBot.ApplicationCore.Interfaces;

namespace TelegramBot.Infrastructure;

public interface IPictureReceiveFactory
{
    public IPictureReceive Process();
}