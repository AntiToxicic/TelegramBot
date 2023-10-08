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

    public async Task<IReadOnlyCollection<User>> GetUser(int id)
    {
        return await _userRepository.GetUser(id);
    }
}