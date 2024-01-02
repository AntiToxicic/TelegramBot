using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;

namespace TelegramBot.Infrastructure;

public class PictureRepository : IPictureRepository
{
    private readonly PostgresContext _context;
    private readonly IConfiguration _config;

    public PictureRepository(PostgresContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public async Task AddPictureInfoAsync(Picture picture)
    {
        await _context.Pictures.AddAsync(picture);
        await _context.SaveChangesAsync();
    }

    public async Task<Picture> GetRandomPictureInfoAsync()
    {
        return (await _context.Pictures
            .OrderBy(p => EF.Functions.Random())
            .FirstOrDefaultAsync())!;
    }



    public async Task<Picture> GetStartPictureInfoAsync()
    {
        string? path = _config.GetSection("PictureStorage").GetValue<string>("StartPicture");
        
        var picture = (await _context.Pictures.FirstOrDefaultAsync(c =>
            c.Path == path))!;
        
        return picture;
    }

    public async Task<Picture> GetPicture(long picId)
    {
        var picture = _context.Pictures.FirstOrDefault(c =>
            c.Id == picId)!;
        
        return picture; 
    }

    public async Task<string> GeneratePathAsync(long userId)
    {
        string picPath = $@"{_config.GetSection("PictureStorage").GetValue<string>("path")}{userId}/";

        Directory.CreateDirectory(picPath);

        return picPath;
    }

    public async Task<int> GetPictureCountOfUser(long userId) =>
        await _context.Pictures.CountAsync(p => p.UserId == userId);

    public async Task DeleteAllUserPictures(long userId)
    {
        var admin = await _context.Users.FirstOrDefaultAsync(a => a.Id == userId);
        var picture = await _context.Pictures.FirstOrDefaultAsync(p => p.Id == admin.PictureIdForRate);
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == picture.UserId);

        var allPictures = await _context.Pictures.Where(p => p.UserId == user.Id).ToListAsync();

        foreach (var pic in allPictures)
        {
            string path = pic.Path;

            if (File.Exists(path))
                File.Delete(path);

            _context.Pictures.Remove(pic);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<User> DeleteUserPicture(long userId)
    {
        var admin = await _context.Users.FirstOrDefaultAsync(a => a.Id == userId);
        var picture = await _context.Pictures.FirstOrDefaultAsync(p => p.Id == admin.PictureIdForRate);

        if (File.Exists((picture.Path)))
            File.Delete(picture.Path);
        
        _context.Pictures.Remove(picture);
        await _context.SaveChangesAsync();

        return (await _context.Users.FirstOrDefaultAsync(u => u.Id == picture.UserId))!;
    }
}