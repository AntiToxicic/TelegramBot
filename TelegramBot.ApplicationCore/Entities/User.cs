namespace TelegramBot.ApplicationCore.Entities;

public class User : EntityBase
{
    public User(long id, string? name, Statuses status = Statuses.START)
    {
        Id = id;
        Name = name;
        Status = status;
    }

    public int Rating { get; set; } = 0;
    public int Uploads { get; set; } = 0;
    public string? Name { get; set; }
    public Statuses Status { get; set; }
    public long PictureIdForRate { get; set; } = 1;
}