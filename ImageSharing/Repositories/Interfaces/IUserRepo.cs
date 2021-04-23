using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSharing.Models;

namespace ImageSharing.Repositories.Interfaces
{
    interface IUserRepo
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> AddUserAsync(User user);
    }
}
