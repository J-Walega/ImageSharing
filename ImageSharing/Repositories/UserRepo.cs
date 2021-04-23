using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSharing.Data;
using ImageSharing.Models;
using ImageSharing.Repositories.Interfaces;

namespace ImageSharing.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext;

        public Task<bool> AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
