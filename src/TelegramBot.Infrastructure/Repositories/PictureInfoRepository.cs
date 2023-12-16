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

    public async Task AddAsync(PictureInfo picture, CancellationToken cancellationToken)
    {
        await _context.PicturesInfos.AddAsync(picture, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<PictureInfo?> Random(CancellationToken cancellationToken)
    {
        // TODO: change implementation
        var rand = new Random();
        int toSkip = rand.Next(_context.PicturesInfos.Count());

        return await _context.PicturesInfos.Skip(toSkip).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task IterLikeCount(long id, CancellationToken cancellationToken)
    {
        var pictureInfo = await _context.PicturesInfos.FirstAsync(c => c.Id == id, cancellationToken);

        // TODO: change implementation
        pictureInfo.LikeCount++;

        _context.PicturesInfos.Update(pictureInfo);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
