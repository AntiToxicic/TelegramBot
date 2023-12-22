using TelegramBot.ApplicationCore.Common;

namespace TelegramBot.ApplicationCore.Entities;

public class Like : EntityBase
{
    public Like() { }

    public Like(long userId, long pictureInfoId)
    {
        UserId = userId;
        PictureInfoId = pictureInfoId;
    }

    public long UserId { get; private set; }

    public virtual User User { get; set; } = null!;

    public long PictureInfoId { get; private set; }

    public virtual PictureInfo PictureInfo { get; set; } = null!;
}
