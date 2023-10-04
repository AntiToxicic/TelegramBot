using System.Data.Common;

namespace TelegramBot;

class Answers
{
    const string toWatch  = "Смотреть"; 
    const string toUpload  = "Загрузить картинку"; 
    const string like = "Нравится"; 
    const string disLike  = "Не нравится"; 
    const string toMenu  = "Меню"; 
    const string wrongAnswer  = "Нет такого варианта ответа"; 

    const string menuScript  = "1. Смотреть картинки\n2. Загрузить картинку"; 



    static public Func<string, string>? DefineAnswer(long id)
    {
        int state = 0;
        //state = db.Users[id].state;

        return state switch
        {
            0 => SendAnswerFromMenu!,
            1 => SendAnswerFromScroll!,
            _ => null
        };
    }

    static private string? SendAnswerFromMenu(string text)
    {
        Random random = new();

        switch(text)
        {
            case toWatch: 
                using (TbotContext db = new TbotContext())
                {
                    
                    var imageId = random.Next(db.Images.ToList().Count);
                    
                    string? path = db.Images.ToList()[imageId].Path;

                }
                //db.Users[id].state = (int)State.ScrollImages;
            break;

            case toUpload: 
                //db.Users[id].state = (int)State.UpLoadImages;
            break;

            default:
                return wrongAnswer;
        }

        return null;
    }

    static private string? SendAnswerFromScroll(string text)
    {
        switch(text)
        {
            case toMenu: 
                //db.Users[id].state = (int)State.StartMenu;
                return menuScript;
            break;

            case like: 
                //db.Images+=1; some magic
            break;

            case disLike: 
                //db.Images+=1; some magic
            break;

            default:
                return wrongAnswer;
        }

        return null;
    }
}