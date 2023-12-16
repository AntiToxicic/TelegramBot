using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;

namespace TelegramBot.Infrastructure.Repositories;

public class LikeRepository : ILikeRepository
{
    private readonly PostgresContext _context;

    public LikeRepository(PostgresContext context)
    {
        _context = context;
    }

    public async Task<bool> AddIfNotExistAsync(Like like, CancellationToken cancellationToken)
    {
        await _context.Likes.AddAsync(like, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
