namespace TelegramBot.Telegram;

public class TelegramCommands
{
    private static readonly IConfiguration _config = new ConfigurationBuilder()
        .AddUserSecrets<TelegramCommands>()
        .Build();
    
    public static readonly string START = _config.GetSection("TELEGRAMCOMMANDS").GetValue<string>("START")!;
    public static readonly string RULES = _config.GetSection("TELEGRAMCOMMANDS").GetValue<string>("RULES")!;
    public static readonly string STATISTIC = _config.GetSection("TELEGRAMCOMMANDS").GetValue<string>("STATISTIC")!;
    public static readonly string GETPICUTRE = _config.GetSection("TELEGRAMCOMMANDS").GetValue<string>("GETPICUTRE")!;
    public static readonly string UPLOADPICTURE = _config.GetSection("TELEGRAMCOMMANDS").GetValue<string>("UPLOADPICTURE")!;
    public static readonly string GETSTART = _config.GetSection("TELEGRAMCOMMANDS").GetValue<string>("GETSTART")!;
    public static readonly string GETBACK = _config.GetSection("TELEGRAMCOMMANDS").GetValue<string>("GETBACK")!;
    public static readonly string LIKE = _config.GetSection("TELEGRAMCOMMANDS").GetValue<string>("LIKE")!;
}