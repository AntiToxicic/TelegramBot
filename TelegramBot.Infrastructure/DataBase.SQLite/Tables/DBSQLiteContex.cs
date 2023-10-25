using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TelegramBot.Infrastructure.DataBase.SQLite.Tables;

public class DBSQLiteContex : DbContext
{
        IConfiguration config = new ConfigurationBuilder()
            .AddUserSecrets<DBSQLiteContex>()
            .Build();
    
    public DBSQLiteContex()
    {
       // Database.EnsureDeleted();
       // Database.OpenConnection();
       try
       {
           Database.EnsureCreated();

       }
       catch (Exception e){}
    }

    public DBSQLiteContex(DbContextOptions<DBSQLiteContex> options)
        : base(options)
    {
    }

    public virtual DbSet<PictureDBTable> Pictures { get; set; }
    public virtual DbSet<UserDBTable> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var name = config.GetSection("DataBase").GetValue<string>("name");
        var password = config.GetSection("DataBase").GetValue<string>("password");
        optionsBuilder.UseNpgsql($"Host=localhost;Port=5432;Database={name};Username=postgres;Password={password}");
    }
}