namespace TelegramBot.ApplicationCore.Entities;

public class Picture : EntityBase
{
    public Picture(string path, string? caption, long userId)
    {
        Path = path;
        Caption = caption;
        UserId = userId;
    }
    
    public string TelegramPicId { get; set; }
    public string Path { get; set; }
    public string? Caption { get; set; }
    public long UserId { get; set; }
    public int Likes { get; set; } = 0;
}