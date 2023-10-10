namespace TelegramBot.Telegram.Telegram;

public static class LastMessage
{
    private static Dictionary<long, string> Messages = new();

    public static string GetMessage(long chatId)
    {
        try
        {
            return Messages[chatId];
        }
        catch (KeyNotFoundException)
        {
            return "";
        }
    }

    public static void SaveMessage(long chatId, string text)
    {
        Messages[chatId] = text;
    }
}