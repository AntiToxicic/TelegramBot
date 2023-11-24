using Telegram.Bot;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;

namespace TelegramBot.Telegram.Common;

public class UserInfoReceiving : IUserInfoReceiving
{
    private readonly ITelegramBotClient _botClient;

    public UserInfoReceiving(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async Task<User> GetUserInfoAsync(long chatId)
    {
        var chat = await _botClient.GetChatAsync(chatId);

        return new User(
            id: chatId,
            name: chat.Username);
    }
}