using Telegram.Bot.Types;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;

namespace TelegramBot.ApplicationCore.Services;

public class PictureService : IPictureService
{
    private IPictureRepository _pictureRepository;

    public PictureService(
        IPictureRepository pictureRepository
       )
    {
        _pictureRepository = pictureRepository;
    }

    public async Task<Picture> GetPicture()
    {
        return await _pictureRepository.GetPicture();
    }
    
    public async Task RecordPicture(long picId, long userId, string picPath, string caption = "Без подписи")
    {
        await _pictureRepository.RecordPicture(picId, userId, picPath, caption);
    }
}