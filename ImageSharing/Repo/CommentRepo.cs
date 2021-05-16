using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSharing.Data;
using ImageSharing.Domain;
using ImageSharing.Repo.Interfaces;

namespace ImageSharing.Repo
{
    public class CommentRepo : ICommentRepo
    {
        private readonly DataContext _context;

        public CommentRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCommentAsync(Comment comment, string userId, Guid imageId)
        {
            await _context.AddAsync(comment);
            return await SaveChanges();
        }

        public Task<IEnumerable<Comment>> GetCommentsByImageIdAsync(Guid imageId)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
