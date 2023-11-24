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
}