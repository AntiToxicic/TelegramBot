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
        var userTemp = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
        
        if (userTemp is not null)
            return;
        
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public Task<User?> GetUserAsync(long chatId) =>
        _context.Users.FirstOrDefaultAsync(u => u.Id == chatId)!;

    public async Task SetStatusAsync(Statuses status, long chatId)
    {
        var user = (await _context.Users.FirstOrDefaultAsync(u => u.Id == chatId))!;
        user.Status = status;
        
        await _context.SaveChangesAsync();
    }

    public async Task SetPictureIdForRatingAsync(long picId, long userId)
    {
        var user = (await _context.Users.FirstOrDefaultAsync(u => u.Id == userId))!;
        user.PictureIdForRate = picId;
        
        await _context.SaveChangesAsync();
    }

    public async Task<User> BanUserAsync(long userId)
    {
        var admin =  await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        var id = (await _context.Pictures.FirstOrDefaultAsync(p => p.Id == admin.PictureIdForRate)).UserId;
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        user.Status = Statuses.BANNED;

        await _context.SaveChangesAsync();

        return user;
    }
}