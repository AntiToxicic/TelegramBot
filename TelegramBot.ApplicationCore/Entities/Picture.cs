namespace TelegramBot.ApplicationCore.Entities;

public class Picture : EntityBase
{
    public Picture(string path, string? caption, long userId)
    {
        Path = path;
        Caption = caption;
        UserId = userId;
    }
    
    public string Path { get; set; }
    public string? Caption { get; set; }
    public long UserId { get; set; }
    public int Rating { get; set; } = 0;
    public User[]? UsersLiked { get; set; } = null;
}