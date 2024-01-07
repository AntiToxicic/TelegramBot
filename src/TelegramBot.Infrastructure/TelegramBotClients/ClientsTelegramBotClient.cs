using Telegram.Bot;
using TelegramBot.Infrastructure.Interfaces;

namespace TelegramBot.Infrastructure.TelegramBotClients;

public class ClientsTelegramBotClient : TelegramBotClient, IClientsTelegramBotClient
{
    public ClientsTelegramBotClient(TelegramBotClientOptions options, HttpClient? httpClient = null) : base(options, httpClient)
    {
    }

    public ClientsTelegramBotClient(string token, HttpClient? httpClient = null) : base(token, httpClient)
    {
    }
}
