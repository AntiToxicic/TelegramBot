namespace TelegramBot.ApplicationCore.Interfaces;

public interface IMessageService
{
    Task SendMessage(long chatId, string text, CancellationToken cancellationToken);
}
