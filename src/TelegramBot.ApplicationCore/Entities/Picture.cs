using TelegramBot.ApplicationCore.Common;

namespace TelegramBot.ApplicationCore.Entities;

public class Picture : EntityBase
{
    public Picture() { }
    public Picture(long userId, string uriPath, string? caption)
    {
        UserId = userId;
        UriPath = uriPath;
        Caption = caption;
    }

    public long UserId { get; private set; }

    public string UriPath { get; private set; }
    public string? Caption { get; private set; }
}
