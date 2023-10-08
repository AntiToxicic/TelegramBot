using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.Infrastructure.DataBase.Tables;

namespace TelegramBot.Infrastructure.DataBase;

public class PictureRepository : IPictureRepository
{
    public async Task<Picture> GetPicture(int id)
    {
        PictureDBTable picture;
        string path = "nothing";
        string caption = "nothing";
        
        using (DBSQLiteContex db = new DBSQLiteContex())
        {
           // PictureDBTable pc = new("C/Users/Alex", "Awsome caption"){Id = 34};
            //db.Picture.AddRange(pc);
           // db.SaveChanges();
            
          //  Console.WriteLine(db.Picture.ToList().Count);
            foreach (var temp in db.Picture.ToList())
            {
              //  Console.WriteLine($"temp.Id = {temp.Id} || id = {id}");
                if (temp.Id == id)
                {
                    path = temp.path;
                    caption = temp.caption;
                    break;
                }
            }
        }
        
        picture = new PictureDBTable(path, caption);

        return picture;
    }
}