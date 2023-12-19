namespace TelegramBot.ApplicationCore.Common;

public class EntityBase
{
    public long Id { get; protected init; }
    public DateTimeOffset CraatedBy { get; init; } = DateTimeOffset.UtcNow;
}
