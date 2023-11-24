﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;

namespace TelegramBot.Infrastructure;

public class PictureRepository : IPictureRepository
{
    private readonly PostgresContext _context;
    private readonly IConfiguration _config;

    public PictureRepository(PostgresContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public async Task AddPictureInfoAsync(Picture picture)
    {
        await _context.Pictures.AddAsync(picture);
        await _context.SaveChangesAsync();
    }

    public async Task<Picture?> GetRandomPictureInfoAsync()
    {
        Random rand = new Random();  
        int toSkip = rand.Next(1, _context.Pictures.Count()) - 1;
        return  _context.Pictures.Skip(toSkip).FirstOrDefault();
    }

    public async Task<Picture?> GetStartPictureInfoAsync()
    {
        string? path = _config.GetSection("PictureStorage").GetValue<string>("StartPicture");
        
        Picture? picture = _context.Pictures.FirstOrDefault(c =>
            c.Path == path);
        
        return picture;
    }

    public async Task<string> GeneratePathAsync(long userId)
    {
        string picPath = $@"{_config.GetSection("PictureStorage").GetValue<string>("path")}{userId}/";

        Directory.CreateDirectory(picPath);

        return picPath;
    }
}