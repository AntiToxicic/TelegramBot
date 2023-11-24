namespace TelegramBot.Telegram;

public class BotTextAnswers
{
    private static readonly IConfiguration _config = new ConfigurationBuilder()
        .AddUserSecrets<TelegramCommands>()
        .Build();

    public static string START = _config.GetSection("BOTANSWERS").GetValue<string>("START") + TelegramCommands.RULES;
    public static string AWAITPICTURE = _config.GetSection("BOTANSWERS").GetValue<string>("AWAITPICTURE")!;
    public static string ACCEPTPICTURE = _config.GetSection("BOTANSWERS").GetValue<string>("ACCEPTPICTURE")!;
    public static string WRONGANSWER = _config.GetSection("BOTANSWERS").GetValue<string>("WRONGANSWER")!;
    public static string CONTINUE = _config.GetSection("BOTANSWERS").GetValue<string>("CONTINUE")!;
    
    public static string RULES = _config.GetSection("BOTANSWERS").GetSection("RULES").GetValue<string>("RULE1") +
                                  _config.GetSection("BOTANSWERS").GetSection("RULES").GetValue<string>("RULE2") +
                                  _config.GetSection("BOTANSWERS").GetSection("RULES").GetValue<string>("RULE3") +
                                  _config.GetSection("BOTANSWERS").GetSection("RULES").GetValue<string>("RULE4");
}