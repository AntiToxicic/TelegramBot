using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface IPictureRepository
{
    Task AddPictureInfoAsync(Picture picture);
    Task<Picture> GetRandomPictureInfoAsync();
    Task<Picture> GetStartPictureInfoAsync();
    Task<Picture> GetPicture(long picId);
    Task<string> GeneratePathAsync(long userId);
    Task<int> GetPictureCountOfUser(long userId);
    Task DeleteAllUserPictures(long userId);
    Task<User> DeleteUserPicture(long userId);
}