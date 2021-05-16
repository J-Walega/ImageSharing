using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSharing.Domain;

namespace ImageSharing.Repo.Interfaces
{
    public interface IImageRepo
    {
        Task<bool> UploadImageAsync(Image image);
        Task<IEnumerable<Image>> GetImagesAsync();
        Task<Image> GetImageByIdAsync(Guid imageId);
        Task<IEnumerable<Image>> GetUserImagesAsync(Guid userId);
        Task<bool> DeleteImageAsync(Image image);
    }
}
