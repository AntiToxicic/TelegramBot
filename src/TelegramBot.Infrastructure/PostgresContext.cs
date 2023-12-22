using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.Infrastructure.Configurations;

namespace TelegramBot.Infrastructure;

public class PostgresContext : DbContext
{
    private readonly IConfiguration _config;

    public PostgresContext(DbContextOptions<PostgresContext> options, IConfiguration config) : base(options)
    {
        _config = config;
    }
    public DbSet<PictureInfo> PicturesInfos { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Like> Likes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PictureInfoConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new LikeConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var name = $@"{_config.GetSection("DataBase").GetValue<string>("name")}";
        var password = $@"{_config.GetSection("DataBase").GetValue<string>("password")}";
        optionsBuilder.UseNpgsql($@"Host=localhost;Port=5432;Database={name};Username=postgres;Password={password}");
    }
}
