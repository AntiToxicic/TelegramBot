using Microsoft.EntityFrameworkCore;

namespace TelegramBot.Infrastructure.DataBase.Tables;

public class DBSQLiteContex : DbContext
{
    public DBSQLiteContex()
    {
       //   Database.EnsureDeleted();
       // Database.EnsureCreated();
       Database.OpenConnection();
    
    }

    public DBSQLiteContex(DbContextOptions<DBSQLiteContex> options)
        : base(options)
    {
    }

    public virtual DbSet<PictureDBTable> Picture { get; set; }
    public virtual DbSet<UserDBTable> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        string DataBasePath = "Data Source=C://Users//Alex//Downloads//test.db";
        optionsBuilder.UseSqlite(DataBasePath);
    }
}