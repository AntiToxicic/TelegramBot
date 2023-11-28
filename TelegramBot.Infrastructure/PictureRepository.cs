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
        Random rand = new Random();
        int toSkip = rand.Next(_context.Pictures.Count());
        
        return  (await _context.Pictures.Skip(toSkip).FirstOrDefaultAsync())!;
    }

    public async Task<Picture> GetStartPictureInfoAsync()
    {
        string? path = _config.GetSection("PictureStorage").GetValue<string>("StartPicture");
        
        Picture picture = _context.Pictures.FirstOrDefault(c =>
            c.Path == path)!;
        
        return picture;
    }

    public async Task<string> GeneratePathAsync(long userId)
    {
        string picPath = $@"{_config.GetSection("PictureStorage").GetValue<string>("path")}{userId}/";

        Directory.CreateDirectory(picPath);

        return picPath;
    }

    public async Task IncreasePositiveRatingAsync(long userId)
    {
        var picId = (await _context.Users.FirstOrDefaultAsync
            (p => p.Id == userId))!.PictureIdForRate;
        
        int? newRating = (await _context.Pictures.FirstOrDefaultAsync
            (p => p.Id == picId))?.Likes;

        if (newRating is null) newRating = 1;
        else newRating++;
        
        await _context.Pictures
            .Where(u => u.Id == picId)
            .ExecuteUpdateAsync(b =>
                b.SetProperty(u => u.Likes, newRating));
        await _context.SaveChangesAsync();
    }
}