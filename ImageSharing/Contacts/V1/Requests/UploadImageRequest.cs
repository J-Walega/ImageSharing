using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImageSharing.Contacts.V1.Requests
{
    public class UploadImageRequest
    {
        [Required]
        public string Title { get; set; }

    }
}
