using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;

namespace TelegramBot;

public partial class TbotContext : DbContext
{
    

    public TbotContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public TbotContext(DbContextOptions<TbotContext> options)
        : base(options)
    {
        
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Image> Images { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        string DataBasePath = config["DataBasePath"];
        optionsBuilder.UseSqlite(DataBasePath);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
