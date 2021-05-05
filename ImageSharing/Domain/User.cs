using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImageSharing.Domain
{
    public class User
    {
        public User()
        {
            CreatedDate = DateTime.UtcNow;
        }

        [Key]
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
