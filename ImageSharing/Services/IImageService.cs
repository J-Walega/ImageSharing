using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSharing.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ImageSharing.Services
{
    public interface IImageService
    {
        Task<Image> GetImagesAsync();
        Task<Image> GetImagesByUsername(string username);
        Task<bool> UploadAsync(Image image);
        Task<bool> DeleteAsync(string username);
    }
}
