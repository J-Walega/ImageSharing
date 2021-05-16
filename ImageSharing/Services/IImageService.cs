using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSharing.Contacts.V1.Responses;
using ImageSharing.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageSharing.Services
{
    public interface IImageService
    {
        Task<List<Image>> GetImagesAsync();
        Task<List<Image>> GetImagesByUserId(string userId);
        Task<Image> GetImageByIdAsync(Guid imageId);
        Task<UploadImageResult> UploadImageAsync(IFormFile image, string title, string username);
        Task<DeleteImageResponse> DeleteImageByIdAsync(Guid imageId, Guid userId);
    }
}
