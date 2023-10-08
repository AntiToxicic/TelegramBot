using Telegram.Bot.Types;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;

namespace TelegramBot.ApplicationCore.Services;

public class PictureService : IPictureService
{
    private IPictureRepository _pictureRepository;
    private IPictureTransfer _pictureTransfer;
  //  private IPictureReceive _pictureReceive;

    public PictureService(
        IPictureRepository pictureRepository
        , IPictureTransfer pictureTransfer
       // , IPictureReceive pictureReceive
       )
    {
        _pictureRepository = pictureRepository;
        _pictureTransfer = pictureTransfer;
       // _pictureReceive = pictureReceive;
    }

    public async Task<Picture> GetPicture(int id)
    {
        return await _pictureRepository.GetPicture(id);
    }

    public async Task<IReadOnlyCollection<Picture>> SendPicture(int id)
    {
        return await _pictureTransfer.SendPicture(id);
    }

    // public async Task SavePicture(Update update)
    // {
    //     await _pictureReceive.SavePicture(update);
    // }
}