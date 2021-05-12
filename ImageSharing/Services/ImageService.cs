using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSharing.Data;
using ImageSharing.Domain;
using ImageSharing.Options;
using ImageSharing.Repo.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ImageSharing.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepo _imageRepo;
        private readonly JwtSettings _jwtSettings;

        public ImageService(IImageRepo imageRepo, JwtSettings jwtSettings)
        {
            _imageRepo = imageRepo;
            _jwtSettings = jwtSettings;
        }

        public Task<bool> DeleteImageAsync(string username, Guid imageId)
        {
            throw new NotImplementedException();
        }

        public Task<Image> GetImagesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Image> GetImagesByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UploadImageAsync(IFormFile image, string title)
        {
            throw new NotImplementedException();
        }
    }
}
