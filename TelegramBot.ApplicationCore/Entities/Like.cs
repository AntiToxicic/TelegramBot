namespace TelegramBot.ApplicationCore.Entities;

public class Like : EntityBase
{
    public long UserId { get; set; }
    public User User { get; set; } = null!;
    
    public long PictureId { get; set; }
    public Picture Picture { get; set; } = null!;
}