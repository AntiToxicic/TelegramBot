﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.Infrastructure;

public class PostgresContext : DbContext
{
    private readonly IConfiguration _config;

    public PostgresContext(IConfiguration config)
    {
        _config = config;
        try
        {
            Database.EnsureCreated();
        }
        catch (Exception) {}
    }

    public DbSet<Picture> Pictures { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var name = $@"{_config.GetSection("DataBase").GetValue<string>("name")}";
        var password = $@"{_config.GetSection("DataBase").GetValue<string>("password")}";
        optionsBuilder.UseNpgsql($@"Host=localhost;Port=5432;Database={name};Username=postgres;Password={password}");
    }
}