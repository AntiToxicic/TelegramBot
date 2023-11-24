using MediatR;
using Telegram.Bot;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Requests.Commands;

namespace TelegramBot.ApplicationCore.Handlers.Commands;

public class SavePictureCommandHandler : IRequestHandler<SavePictureCommand>
{
    private readonly IPictureRepository _pictureRepository;
    private readonly IPictureDownloader _pictureDownloader;
    private readonly ITelegramBotClient _botClient;
    
    public SavePictureCommandHandler(IPictureRepository pictureRepository, IPictureDownloader pictureDownloader, ITelegramBotClient botClient)
    {
        _pictureRepository = pictureRepository;
        _pictureDownloader = pictureDownloader;
        _botClient = botClient;
    }


    public async Task Handle(SavePictureCommand request, CancellationToken cancellationToken)
    {
        var path = (await _botClient.GetFileAsync(request.PicId)).FilePath!;
        
        Picture picture = await _pictureDownloader.DownloadAsync(
            picId: request.PicId,
            filePath: path,
            caption: request.Caption,
            userId: request.UserId);
        
        await _pictureRepository.AddPictureInfoAsync(picture);
    }
}