namespace TelegramBot.Telegram;

public class TelegramCommands
{
    private static readonly IConfiguration _config = new ConfigurationBuilder()
        .AddUserSecrets<TelegramCommands>()
        .Build();
    
    public static string START = _config.GetSection("TELEGRAMCOMMANDS").GetValue<string>("START")!;
    public static string RULES = _config.GetSection("TELEGRAMCOMMANDS").GetValue<string>("RULES")!;
    public static string STATICTIC = _config.GetSection("TELEGRAMCOMMANDS").GetValue<string>("STATISTIC")!;
    public static string GETPICUTRE = _config.GetSection("TELEGRAMCOMMANDS").GetValue<string>("GETPICUTRE")!;
    public static string UPLOADPICTURE = _config.GetSection("TELEGRAMCOMMANDS").GetValue<string>("UPLOADPICTURE")!;
    public static string OK = _config.GetSection("TELEGRAMCOMMANDS").GetValue<string>("OK")!;
    public static string GETBACK = _config.GetSection("TELEGRAMCOMMANDS").GetValue<string>("GETBACK")!;
    public static string LIKE = _config.GetSection("TELEGRAMCOMMANDS").GetValue<string>("LIKE")!;
}