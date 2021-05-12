using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSharing.Contacts.V1;
using ImageSharing.Contacts.V1.Requests;
using ImageSharing.Contacts.V1.Responses;
using ImageSharing.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ImageSharing.Controllers.V1
{
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;
        private readonly IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png" };

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost(ApiRoutes.Images.Post)]
        public async Task<IActionResult> PostImage([FromForm] UploadImageRequest request)
        {

            if(request.File == null)
            {
                return BadRequest(new UploadImageResult
                {
                    Success = false,
                    Error = "Select a file to upload"
                });
            }


            var response = await _imageService.UploadImageAsync(request.File, request.Title);

            return Ok(new UploadImageResult
            {
                Success = true
            });
        }
    }
}
