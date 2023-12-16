using Microsoft.EntityFrameworkCore;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.Infrastructure.Configurations;

namespace TelegramBot.Infrastructure;

public class PostgresContext : DbContext
{
    public DbSet<PictureInfo> PicturesInfos { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Like> Likes { get; set; } = null!;

    public PostgresContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PictureInfoConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new LikeConfiguration());
    }
}
