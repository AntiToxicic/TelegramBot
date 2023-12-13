using Microsoft.EntityFrameworkCore;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;

namespace TelegramBot.Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly PostgresContext _context;

    public UserRepository(PostgresContext context)
    {
        _context = context;
    }

    public async Task AddUserAsync(User user)
    {
        var userTemp = await _context.Users.FirstOrDefaultAsync(c => c.Id == user.Id);
        
        if (userTemp is not null)
            return;
        
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public Task<User> GetUserAsync(long chatId) =>
        _context.Users.FirstOrDefaultAsync(c => c.Id == chatId)!;

    public async Task SetStatusAsync(Statuses status, long chatId)
    {
         await _context.Users
            .Where(u => u.Id == chatId)
            .ExecuteUpdateAsync(b =>
                b.SetProperty(u => u.Status, status));
         await _context.SaveChangesAsync();
    }

    public async Task SetPictureIdForRatingAsync(long picId, long userId)
    {
        await _context.Users
            .Where(u => u.Id == userId)
            .ExecuteUpdateAsync(b =>
                b.SetProperty(u => u.PictureIdForRate, picId));
        await _context.SaveChangesAsync();
    }

    public async Task IncreaseUserRatingAsync(long userId)
    {
        int newRating = (await _context.Users.FirstOrDefaultAsync
            (u => u.Id == userId))!.Rating;
        
        newRating++;
        
        await _context.Users
            .Where(u => u.Id == userId)
            .ExecuteUpdateAsync(b =>
                b.SetProperty(u => u.Rating, newRating));
        await _context.SaveChangesAsync();
    }

    public async Task IncreaseUserUploadsCountAsync(long userId)
    {
        int newRating = (await _context.Users.FirstOrDefaultAsync
            (u => u.Id == userId))!.Uploads;
        
        newRating++;
        
        await _context.Users
            .Where(u => u.Id == userId)
            .ExecuteUpdateAsync(b =>
                b.SetProperty(u => u.Uploads, newRating));
        await _context.SaveChangesAsync();
    }
}