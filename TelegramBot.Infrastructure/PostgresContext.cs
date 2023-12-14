using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.Infrastructure;

public class PostgresContext : DbContext
{
    private readonly IConfiguration _config;

    public PostgresContext(IConfiguration config)
    {
        _config = config;

        if (Database.EnsureCreated())
        {
            User user = new User(id: 1, name: "admin")
            {
                Pictures =
                {
                    new Picture(
                        path: $@"{_config.GetSection("PictureStorage").GetValue<string>("StartPicture")}",
                        caption: "Это первая картинка")
                }
            };

            Users.AddAsync(user);
        }
    }

    public DbSet<Picture> Pictures { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Like> Likes { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var name = $@"{_config.GetSection("DataBase").GetValue<string>("name")}";
        var password = $@"{_config.GetSection("DataBase").GetValue<string>("password")}";
        optionsBuilder.UseNpgsql($@"Host=localhost;Port=5432;Database={name};Username=postgres;Password={password}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(e => e.Pictures)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .IsRequired(false);
        
        modelBuilder.Entity<User>()
            .HasMany(e => e.Likes)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .IsRequired();
        
        modelBuilder.Entity<Picture>()
            .HasMany(e => e.Likes)
            .WithOne(e => e.Picture)
            .HasForeignKey(e => e.PictureId)
            .IsRequired();
    }
}