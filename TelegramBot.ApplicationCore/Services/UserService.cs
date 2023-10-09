using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;

namespace TelegramBot.ApplicationCore.Services;

public class UserService : IUserService
{
    private IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUser(long userId)
    {
        return await _userRepository.GetUser(userId);
    }

    public async Task RecordUser(long userId, string userName)
    {
        await _userRepository.RecordUser(userId, userName);
    }
}