using OnlyPics.ApplicationCore.Entities;

namespace OnlyPics.ApplicationCore.Interfaces;

public interface IPictureService
{
    Task<IReadOnlyCollection<Picture>> GetPicture();
}