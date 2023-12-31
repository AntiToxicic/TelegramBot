using TelegramBot.ApplicationCore.Common;
using TelegramBot.ApplicationCore.Enums;

namespace TelegramBot.ApplicationCore.Entities;

public class User : EntityBase
{
    public User() { }
    public User(long chatId, string? name)
    {
        ChatId = chatId;
        Name = name;
    }

    public long? LastReceivedPictureInfoId { get; set; }
    public long ChatId { get; init; }
    public string? Name { get; set; }
    public UserStatus Status { get; set; } = UserStatus.Start;
}
