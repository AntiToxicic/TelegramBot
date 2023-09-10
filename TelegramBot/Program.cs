using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Microsoft.Extensions.Configuration;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot;

//token
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string token = config["token"];                                                             

//connect to bot
HttpClient httpClient = new();
var botClient = new TelegramBotClient(token, httpClient);

//message to console
var me = await botClient.GetMeAsync();
Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

//startReceiving
botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync
);

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    var chatId = update.Message.Chat.Id;
    
    switch (update.Message.Text)
    {
        case "/complain": 
            CommandMenu.Complain(chatId);
         return;
        case "/statistic": 
            CommandMenu.Statistic(chatId);
         return;
    }

    









































    if(update.Message.Text == "/complain")
    {
        ReplyKeyboardMarkup replyKeyboardMarkup = 
        new (new[]
                {
                    new KeyboardButton[] {"Да", "Нет"}
                }
            )
            {
                ResizeKeyboard = true
            };

        await botClient.SendTextMessageAsync
        (
            chatId: chatId,
            text: "Че хочешь выбирай",
            replyMarkup: replyKeyboardMarkup
        );
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

Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    return Task.CompletedTask;
}


