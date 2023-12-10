namespace TelegramBot.ApplicationCore.Interfaces;

public interface IMessageSender
{
    Task SendMessageAsync(
        string message,
        long chatId,
        Statuses status);
}