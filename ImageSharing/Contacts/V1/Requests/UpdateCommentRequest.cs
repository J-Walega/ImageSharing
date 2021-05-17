using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImageSharing.Contacts.V1.Requests
{
    public class UpdateCommentRequest
    {
        [Required]
        public string Content { get; set; }
    }
}
