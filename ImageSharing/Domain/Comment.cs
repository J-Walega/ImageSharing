using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ImageSharing.Domain
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public Guid ImageId { get; set; }
        public string Content { get; set; }

        [ForeignKey(nameof(ImageId))]
        public Image Image { get; set; }
    }
}
