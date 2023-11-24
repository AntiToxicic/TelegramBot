using MediatR;

namespace TelegramBot.ApplicationCore.Entities;

public class Picture : EntityBase
{
    public Picture(string picId, string path, string? caption, long userId)
    {
        PicId = picId;
        Path = path;
        Caption = caption;
        UserId = userId;
    }

    public string PicId { get; set; }
    public string Path { get; set; }
    public string? Caption { get; set; }
    public long UserId { get; set; }
}