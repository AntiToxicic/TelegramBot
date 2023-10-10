namespace TelegramBot.ApplicationCore.Entities;

public class EntityBase
{
    public EntityBase(long id)
    {
        Id = id;
    }
    public long Id { get; set; }
}