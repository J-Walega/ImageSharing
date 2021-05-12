using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ImageSharing.Domain
{
    public class Image
    {
        public Image()
        {
            UploadDate = DateTime.UtcNow;
        }

        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public DateTime UploadDate { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }

        [ForeignKey(nameof(Username))]
        public IdentityUser User { get; set; }

    }
}
