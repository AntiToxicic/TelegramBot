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
       // Database.EnsureCreated();
       Database.OpenConnection();
    
    }

    public DBSQLiteContex(DbContextOptions<DBSQLiteContex> options)
        : base(options)
    {
    }

    public virtual DbSet<PictureDBTable> Pictures { get; set; }
    public virtual DbSet<UserDBTable> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var path = config.GetSection("DataBase").GetValue<string>("path");
        var name = config.GetSection("DataBase").GetValue<string>("name");
        string DataBasePath = "Data Source=" + path + name;
        optionsBuilder.UseSqlite(DataBasePath);
    }

}