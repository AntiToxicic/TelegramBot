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
        var rand = new Random();
        int toSkip = rand.Next(_context.Pictures.Count());
        
        return  (await _context.Pictures.Skip(toSkip).FirstOrDefaultAsync())!;
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

    public async Task IncreasePictureRatingAsync(long picId)
    {
        var picture = (await _context.Pictures.FirstOrDefaultAsync(p => p.Id == picId))!;
        picture.Rating++;
        
        await _context.SaveChangesAsync();
    }

    public async Task<int> GetPictureCountOfUser(long userId) =>
        await _context.Pictures.CountAsync(p => p.UserId == userId);

    public async Task AddUserLikedAsync(long userId, long picId)
    {
        var user = (await _context.Users.FirstOrDefaultAsync(u => u.Id == userId))!;
        var picture = (await _context.Pictures.FirstOrDefaultAsync(p => p.Id == picId))!;

        Like like = new Like()
        {
            User = user,
            Picture = picture
        };
        
        await _context.Likes.AddAsync(like);
        await _context.SaveChangesAsync();
    }
}