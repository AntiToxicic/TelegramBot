using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.ApplicationCore.Interfaces;

public interface ILikeRepository
{
    Task AddLikeAsync(User user, Picture picture);
    Task<List<Like>> GetLikes(Picture picture); 
    Task<int> GetLikesCountOfUserAsync(User user);
}