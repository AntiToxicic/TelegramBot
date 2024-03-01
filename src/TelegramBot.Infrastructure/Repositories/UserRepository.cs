using Microsoft.EntityFrameworkCore;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;

namespace TelegramBot.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PostgresContext _context;

    public UserRepository(PostgresContext context)
    {
        _context = context;
    }


    public async Task<User?> GetUserAsync(long chatId, CancellationToken cancellationToken) =>
        await _context.Users.FirstOrDefaultAsync(c => c.ChatId == chatId, cancellationToken);

    public async Task AddUserAsync(User user, CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateLastReceivedPictureInfoIdAsync(User user, long lastReceivedPictureInfoId, CancellationToken cancellationToken)
    {
        user.LastReceivedPictureInfoId = lastReceivedPictureInfoId;

        _context.Users.Update(user);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
