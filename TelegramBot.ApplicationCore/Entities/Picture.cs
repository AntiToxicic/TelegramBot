namespace TelegramBot.ApplicationCore.Entities;

public class Picture : EntityBase
{
    public Picture(string path, string? caption)
    {
        Path = path;
        Caption = caption;
    }
    
    public string Path { get; set; }
    public string? Caption { get; set; }
    public int Rating { get; set; } = 0;

    public long UserId { get; set; }
    public User User { get; set; } = null!;
    
    public ICollection<Like> Likes { get; set; } = new List<Like>();
}