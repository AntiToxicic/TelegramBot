namespace TelegramBot.Telegram;

public class BotTextAnswers
{
    private static readonly IConfiguration _config = new ConfigurationBuilder()
        .AddUserSecrets<TelegramCommands>()
        .Build();

    public static string START = _config.GetSection("BOTANSWERS").GetValue<string>("START") + TelegramCommands.RULES;
    public static string AWAITPICTURE = _config.GetSection("BOTANSWERS").GetValue<string>("AWAITPICTURE")!;
    public static string ACCEPTPICTURE = _config.GetSection("BOTANSWERS").GetValue<string>("ACCEPTPICTURE")!;
    public static string DEFAULT = _config.GetSection("BOTANSWERS").GetValue<string>("DEFAULT")!;
    public static string CONTINUE = _config.GetSection("BOTANSWERS").GetValue<string>("CONTINUE")!;
    public static string NOLIKES = _config.GetSection("BOTANSWERS").GetValue<string>("NOLIKES")!;
    public static string LIKESCOUNT = _config.GetSection("BOTANSWERS").GetValue<string>("LIKESCOUNT")!;
    public static string STATISTIC = _config.GetSection("BOTANSWERS").GetSection("STATISTIC").GetValue<string>("TEMPLATE") + "\n" +
                                     "-----\n" +
                                      _config.GetSection("BOTANSWERS").GetSection("STATISTIC").GetValue<string>("LIKES") + "\t{0}\n" +
                                      _config.GetSection("BOTANSWERS").GetSection("STATISTIC").GetValue<string>("UPLOADS") + "\t{1}";
    
    public static string RULES = _config.GetSection("BOTANSWERS").GetSection("RULES").GetValue<string>("TEMPLATE") + "\n" +
                                  _config.GetSection("BOTANSWERS").GetSection("RULES").GetValue<string>("RULE1") + "\n" +
                                  _config.GetSection("BOTANSWERS").GetSection("RULES").GetValue<string>("RULE2") + "\n" +
                                  _config.GetSection("BOTANSWERS").GetSection("RULES").GetValue<string>("RULE3") + "\n" +
                                  _config.GetSection("BOTANSWERS").GetSection("RULES").GetValue<string>("RULE4");
}