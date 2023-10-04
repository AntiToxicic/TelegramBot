namespace TelegramBot;

public class Image
{
    public int Id { get; set; }
    public string? Path { get; set; } // название компании
    public string? Caption {get; set;}
 
    public List<User> Users { get; set; } = new();
}