using System.ComponentModel;
using System.Data.Common;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Exceptions;
using TelegramBot.ApplicationCore.Interfaces;

namespace TelegramBot.Infrastructure.Repositories;

public class LikeRepository : ILikeRepository
{
    private readonly PostgresContext _context;

    public LikeRepository(PostgresContext context)
    {
        _context = context;
    }

    public async Task AddIfNotExistAsync(Like like, CancellationToken cancellationToken)
    {
        try
        {
            await _context.Likes.AddAsync(like, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (DbException e)
        {
            throw new LikeAlreadyExistExeption();
        }
    }
}
