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

    public async Task<Picture> GetPicture(long picId)
    {
        return await _pictureRepository.GetPicture(picId);
    }
    
    public async Task RecordPicture(long chatId, long picId, string userName, string caption)
    {
        await _pictureRepository.RecordPicture(chatId, picId, userName, caption);
    }
}