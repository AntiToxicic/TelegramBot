using Telegram.Bot;
using TelegramBot.Infrastructure.Interfaces;

namespace TelegramBot.Infrastructure.TelegramBotClients;

public class AdminsTelegramBotClient : TelegramBotClient, IAdminsTelegramBotClient
{
    public AdminsTelegramBotClient(TelegramBotClientOptions options, HttpClient? httpClient = null) : base(options, httpClient)
    {
    }

    public AdminsTelegramBotClient(string token, HttpClient? httpClient = null) : base(token, httpClient)
    {
    }
}
