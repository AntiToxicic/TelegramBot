using Microsoft.EntityFrameworkCore;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;

namespace TelegramBot.Infrastructure.Repositories;

public class PictureInfoRepository : IPictureInfoRepository
{
    private readonly PostgresContext _context;

    public PictureInfoRepository(PostgresContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Picture picture, CancellationToken cancellationToken)
    {
        await _context.Pictures.AddAsync(picture, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Picture?> GetRandomPictureAsync(CancellationToken cancellationToken)
    {
        // TODO: change implementation
        var rand = new Random();
        int toSkip = rand.Next(_context.Pictures.Count());

        return await _context.Pictures.Skip(toSkip).FirstOrDefaultAsync(cancellationToken);
    }
}
