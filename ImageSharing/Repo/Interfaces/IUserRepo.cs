using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSharing.Domain;

namespace ImageSharing.Repo.Interfaces
{
    interface IUserRepo
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> AddUserAsync(User user);

    }
}
