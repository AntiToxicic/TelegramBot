using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IPictureRepository
{
    Task AddPictureInfoAsync(Picture picture);
    Task<Picture> GetRandomPictureInfoAsync();
    Task<Picture> GetStartPictureInfoAsync();
    Task<string> GeneratePathAsync(long userId);
    Task IncreasePositiveRatingAsync(long userId); }