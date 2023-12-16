using TelegramBot.ApplicationCore.Common;

namespace TelegramBot.ApplicationCore.Entities;

public class PictureInfo : EntityBase
{
    public PictureInfo() { }
    public PictureInfo(long userId, string path, string? caption)
    {
        UserId = userId;
        Path = path;
        Caption = caption;
    }

    public long UserId { get; set; }

    public string Path { get; set; }
    public string? Caption { get; set; }

    public uint LikeCount { get; set; }
}
