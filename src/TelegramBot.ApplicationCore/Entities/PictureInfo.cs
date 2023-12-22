using TelegramBot.ApplicationCore.Common;

namespace TelegramBot.ApplicationCore.Entities;

public class PictureInfo : EntityBase
{
    public PictureInfo() { }
    public PictureInfo(long userId, string uriPath, string? caption)
    {
        UserId = userId;
        UriPath = uriPath;
        Caption = caption;
    }

    public long UserId { get; private set; }

    public string UriPath { get; private set; }
    public string? Caption { get; private set; }
}
