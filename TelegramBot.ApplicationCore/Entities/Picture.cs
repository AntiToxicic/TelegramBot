namespace TelegramBot.ApplicationCore.Entities;

public class Picture : EntityBase
{
    public Picture(string path = "", string caption = "")
    {
        this.path = path;
        this.caption = caption;
    }
    
    public string path { get; set; }
    public string caption { get; set; }
}