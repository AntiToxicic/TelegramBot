namespace TelegramBot;

public class User
{

    public long Id { get; set; }

    public string? Nick { get; set; }
    public int State {get; set;}
    
    public int ImagesId { get; set; }      // внешний ключ
    public Image? Image { get; set; }  
}
