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

    public async Task<User> GetOrCreate(long chatId, string name, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(c => c.ChatId == chatId, cancellationToken);

        // TODO: change implementation
        if (user == null)
        {
            user = new User(chatId, name);

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        return user;
    }

    public async Task UpdateLastReceivedPictureInfoId(long userId, long lastReceivedPictureInfoId, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstAsync(c => c.Id == userId, cancellationToken);

        user.LastReceivedPictureInfoId = lastReceivedPictureInfoId;

        _context.Users.Update(user);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
