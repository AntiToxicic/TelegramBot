using OnlyPics.ApplicationCore.Entities;
using OnlyPics.ApplicationCore.Interfaces;

namespace OnlyPics.ApplicationCore.Services;

public class PictureService : IPictureService
{
    private readonly IPictureService _pictureService;

    public PictureService(
        IPictureService pictureService)
    {
        _pictureService = pictureService;
    }

    public async Task<IReadOnlyCollection<Picture>> GetPicture()
    {
        return await _pictureService.GetPicture();
    }
}