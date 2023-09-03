using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults; //inline menu
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

HttpClient httpClient = new();

string token = config["token"];

var botClient = new TelegramBotClient(token, httpClient);

string[] sites = { "Google", "Github", "Telegram", "Wikipedia" };
string[] siteDescriptions =
{
    "Google is a search engine",
    "Github is a git repository hosting",
    "Telegram is a messenger",
    "Wikipedia is an open wiki"
};

string answer = "null";

botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync
);








// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.




var me = await botClient.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

// Send cancellation request to stop bot

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    var chatId = update.Message.Chat.Id;

    

    if(update.Message.Text == "/complain" || answer == "/complain")
    {
        answer = "/complain";

        botClient.SendTextMessageAsync(
            chatId: chatId,
            text: "1. Послать вас нахуй?\n2. Бот идет нахуй\n3. Назад"
        );
        if(update.Message.Text != "/complain")
        {    switch (update.Message.Text)
            {
                case "1": 
                    await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Иди нахуй!"
            );
                break;

                case "2": 
                    await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Сам иди нахуй!"
            );
                break;

                case "3": 
                    await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Пошел нахуй, терпила!"
            );
                break;

                default: 
                await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Понятно..."
            );
                break;
            }}

            answer = "null";
            return;
    }

     try
    {
        await (update.Type switch
        {
            UpdateType.InlineQuery => BotOnInlineQueryReceived(botClient, update.InlineQuery!),
            
            _ => Task.CompletedTask
        });
    }

    catch (Exception ex)
    {
        Console.WriteLine($"Exception while handling {update.Type}: {ex}");
    }

    // Only process Message updates: https://core.telegram.org/bots/api#message
    if(update.Message.Photo is {})
    {
        var fileId = update.Message.Photo.Last().FileId;
        var fileInfo = await botClient.GetFileAsync(fileId);
        var filePath = fileInfo.FilePath;

        string UpNamePhoto = "downloaded Photo.jpg";
        string path2 = @"C:/Users/Alex/Downloads/";

        await using Stream stream1 = System.IO.File.Create(path2 + UpNamePhoto);
        await botClient.DownloadFileAsync(
            filePath: filePath,
            destination: stream1
        );

        await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: "Спасибо за фоточку"
        );
    }

    if (update.Message is not {} message)
        return;
    // Only process text messages
    if (message.Text is not { } messageText)
        return;

    

    Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

   




    // Echo received message text

    string namePhoto = "photoTest.jpg";
    string path = @"C:/_Alex/Code/TelegramBot/TelegramBot/";
    
    using (Stream stream = new FileStream(path + namePhoto, FileMode.Open))
    {  
    
        Message photo = await botClient.SendPhotoAsync(
        chatId: chatId,
        photo: InputFile.FromStream(stream, "photoTest.jpg"),
        caption: "Фоточка, на не ней луна",
        parseMode: ParseMode.Html,
        cancellationToken: cancellationToken);  
    }
   
}

async Task BotOnInlineQueryReceived(ITelegramBotClient bot, InlineQuery inlineQuery)
{
    var results = new List<InlineQueryResult>();

    var counter = 0;
    foreach (var site in sites)
    {
        results.Add(new InlineQueryResultArticle(
            $"{counter}", // we use the counter as an id for inline query results
            site, // inline query result title
            new InputTextMessageContent(siteDescriptions[counter])) // content that is submitted when the inline query result title is clicked
        );
        counter++;
    }

    await bot.AnswerInlineQueryAsync(inlineQuery.Id, results); // answer by sending the inline query result list
}

Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    return Task.CompletedTask;
}


