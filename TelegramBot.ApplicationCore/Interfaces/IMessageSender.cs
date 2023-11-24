namespace TelegramBot.ApplicationCore.Interfaces;

public interface IMessageSender
{
    Task SendMessage(
        string message,
        long chatId,
        Statuses status);
}