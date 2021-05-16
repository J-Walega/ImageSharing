using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSharing.Contacts.V1;
using ImageSharing.Contacts.V1.Requests;
using ImageSharing.Contacts.V1.Responses;
using ImageSharing.Extensions;
using ImageSharing.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ImageSharing.Controllers.V1
{
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }
        [Authorize]
        [HttpPost(ApiRoutes.Images.Post)]
        public async Task<IActionResult> PostImage([FromForm] UploadImageRequest request)
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.GetUserId();

                var response = await _imageService.UploadImageAsync(request.File, request.Title, userId);

                return Ok(new UploadImageResult
                {
                    Success = true
                });
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                    .Where(y => y.Count > 0)
                    .ToList();

                return BadRequest(errors);
            }
            return BadRequest();

        }

        [HttpGet(ApiRoutes.Images.GetAll)]
        public async Task<IActionResult> GetImages()
        {
            var result = await _imageService.GetImagesAsync();

            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet(ApiRoutes.Images.GetUserImages)]
        public async Task<IActionResult> GetUserImages()
        {
            var userId = HttpContext.GetUserId();

            var result = await _imageService.GetImagesByUserId(userId);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet(ApiRoutes.Images.Get)]
        public async Task<IActionResult> GetImageById([FromRoute] Guid imageId)
        {
            var result = await _imageService.GetImageByIdAsync(imageId);

            return Ok(result);
        }

        [Authorize]
        [HttpDelete(ApiRoutes.Images.Delete)]
        public async Task<IActionResult> DeleteImage([FromRoute] Guid imageId)
        {
            var userId = HttpContext.GetUserId();

            var response = await _imageService.DeleteImageByIdAsync(imageId, new Guid(userId));

            if(!response.Success)
            {
                return BadRequest(new DeleteImageResponse()
                {
                    Message = response.Message
                });
            }

            return Ok(new DeleteImageResponse()
            {
                Success = response.Success,
                Message = response.Message
            });
        }

       
    }
}
