using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ImageSharing.Extensions;
using Microsoft.AspNetCore.Http;

namespace ImageSharing.Contacts.V1.Requests
{
    public class UploadImageRequest
    {
        [Required]
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile File { get; set; }
        [Required]
        public string Title { get; set; }

    }
}
