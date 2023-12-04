using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.ApplicationCore;
using TelegramBot.Telegram.Interfaces;
using static TelegramBot.Telegram.TelegramCommands;

namespace TelegramBot.Telegram.Common;

public class KeyboardMarkupConstructor : IKeyboardMarkupConstructor
{
    public ReplyKeyboardMarkup GetMarkup(Statuses statuses)
    {
        KeyboardButton[] keyboardButton;
        
        switch (statuses)
        {
            case Statuses.START :
                keyboardButton = new KeyboardButton[] 
                    { GETSTART };
                break;
            case Statuses.WATCH : keyboardButton = new KeyboardButton[] 
                    { LIKE, 
                        GETPICUTRE,
                        UPLOADPICTURE };
                break;
            case Statuses.AWAITPICTURE : keyboardButton = new KeyboardButton[] 
                    { GETBACK };
                break;
            default: keyboardButton = new KeyboardButton[] 
                { GETPICUTRE,
                    UPLOADPICTURE };
                break;
        }
        
       return new (new[] { keyboardButton
        }) { ResizeKeyboard = true };
    }
}