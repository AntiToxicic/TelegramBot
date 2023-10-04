using OnlyPics.ApplicationCore.Entities;

namespace OnlyPics.ApplicationCore.Interfaces;

public interface IPictureRepository
{
    Task<IReadOnlyCollection<Picture>> GetPicture();
}