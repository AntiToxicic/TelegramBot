namespace TelegramBot.ApplicationCore.Entities;

public class EntityBase
{
    public long Id { get; init; }
    public DateTimeOffset CreatedAt { get; } = DateTimeOffset.UtcNow;
}