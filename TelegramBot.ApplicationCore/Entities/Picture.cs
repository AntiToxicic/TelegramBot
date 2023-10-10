namespace TelegramBot.ApplicationCore.Entities;

public class Picture : EntityBase
{
    public Picture(long id, string path, string caption) : base(id)
    {
        Path = path;
        Caption = caption;
    }
    
    public string Path { get; set; }
    public string? Caption { get; set; }
}