using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSharing.Data;
using ImageSharing.Domain;
using ImageSharing.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ImageSharing.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly DataContext _context;

        public UserRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }

        public async Task<bool> AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            return await SaveChanges();
        }

        private async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
