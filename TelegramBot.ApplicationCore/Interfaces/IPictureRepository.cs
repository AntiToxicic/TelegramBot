using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IPictureRepository
{
    Task AddPictureInfoAsync(Picture picture);
    Task<Picture> GetRandomPictureInfoAsync();
    Task<Picture> GetStartPictureInfoAsync();
    Task<Picture> GetPicture(long picId);
    Task<string> GeneratePathAsync(long userId);
    Task IncreasePictureRatingAsync(long picId);
    Task<int> GetPictureCountOfUser(long userId);
    Task AddUserLikedAsync(long userId, long picId);

}