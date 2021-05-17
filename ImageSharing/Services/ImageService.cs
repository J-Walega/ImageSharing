using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImageSharing.Contacts.V1.Responses;
using ImageSharing.Data;
using ImageSharing.Domain;
using ImageSharing.Options;
using ImageSharing.Repo.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ImageSharing.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepo _imageRepo;
        private readonly JwtSettings _jwtSettings;
        private readonly IWebHostEnvironment _enviromnent;

        public ImageService(IImageRepo imageRepo, JwtSettings jwtSettings, IWebHostEnvironment environment)
        {
            _imageRepo = imageRepo;
            _jwtSettings = jwtSettings;
            _enviromnent = environment;
        }

        public async Task<DeleteImageResponse> DeleteImageByIdAsync(Guid imageId, Guid userId)
        {

            var image = await _imageRepo.GetImageByIdAsync(imageId);
            if (userId.ToString() != image.UserId)
            {
                return new DeleteImageResponse()
                {
                    Success = false,
                    Message = "You don't have permission to delete other users image"
                };
            }
            if (image == null)
            {
                return new DeleteImageResponse()
                {
                    Success = false,
                    Message = "Image doesn't exist"
                };
            }
            var delete = await _imageRepo.DeleteImageAsync(image);
            return new DeleteImageResponse()
            {
                Success = true,
                Message = "Deleted"
            };
        }        

        public async Task<Image> GetImageByIdAsync(Guid imageId)
        {
            var image = await _imageRepo.GetImageByIdAsync(imageId);

            return image;
        }

        public async Task<List<Image>> GetImagesAsync()
        {
            var images = await _imageRepo.GetImagesAsync();

            var response = new List<Image>();

            foreach (var image in images)
            {
                response.Add(image);
            }
            return response;
        }

        public async Task<List<Image>> GetImagesByUserId(string userId)
        {
            Guid id = new Guid(userId);
            var images = await _imageRepo.GetUserImagesAsync(id);

            var response = new List<Image>();

            foreach(var image in images)
            {
                response.Add(image);
            }

            return response;
        }

        public async Task<UploadImageResult> UploadImageAsync(IFormFile image, string title, string userId)
        {
            try
            {
                if (!Directory.Exists(_enviromnent.ContentRootPath + $"\\Uploads\\{userId}\\"))
                {
                    Directory.CreateDirectory(_enviromnent.ContentRootPath + $"\\Uploads\\{userId}\\");
                }
                var imageName = Guid.NewGuid();

                using (FileStream fileStream = System.IO.File.Create(_enviromnent.ContentRootPath + "\\Uploads\\" + userId + "\\" + imageName + image.FileName))
                {
                    await image.CopyToAsync(fileStream);
                    
                    Image imageModel = new Image()
                    {
                        Id = new Guid(),
                        UserId = userId,
                        Title = title,
                        Path = $"/Uploads/{userId}/{imageName}{image.FileName}"
                    };

                    fileStream.Flush();
                    await _imageRepo.UploadImageAsync(imageModel);

                    return new UploadImageResult()
                    {
                        Success = true,
                        Error = ""
                    };
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
