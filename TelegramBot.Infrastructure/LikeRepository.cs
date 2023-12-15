using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;

namespace TelegramBot.Infrastructure;

public class LikeRepository : ILikeRepository
{
    private readonly PostgresContext _context;

    public LikeRepository(PostgresContext context)
    {
        _context = context;
    }
    
    public async Task AddLikeAsync(User user, Picture picture)
    {
        var likeTemp = await _context.Likes.FirstOrDefaultAsync(e => e.User == user && e.Picture == picture );
        
        if (likeTemp is not null)
            return;

        Like like = new Like
        {
            User = user,
            Picture = picture
        };
        
        await _context.Likes.AddAsync(like);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Like>> GetLikes(Picture picture) =>
         await _context.Likes.Where(e => e.PictureId == picture.Id).ToListAsync();
    
    public async Task<int> GetLikesCountOfUserAsync(User user)
    {
        var pictures = await _context.Pictures.Where(p => p.UserId == user.Id).ToListAsync();
        int count = 0;
        
        foreach (var picture in pictures)
        {
            count += await _context.Likes.CountAsync(p => p.PictureId == picture.Id);
        }

        return count;
    }
}