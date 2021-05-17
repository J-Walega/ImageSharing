using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImageSharing.Contacts.V1.Requests
{
    public class PostCommentRequest
    {
        [Required]
        public Guid ImageId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
