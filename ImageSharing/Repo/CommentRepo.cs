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
    public class CommentRepo : ICommentRepo
    {
        private readonly DataContext _context;

        public CommentRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCommentAsync(Comment comment)
        {
            await _context.AddAsync(comment);
            return await SaveChanges();
        }

        public async Task<IEnumerable<Comment>> GetCommentsByImageIdAsync(Guid imageId)
        {
            var comments = await _context.Comments
                .Where(u => u.ImageId == imageId)
                .ToListAsync();
            return comments;
        }

        public Comment GetCommentById(Guid id)
        {
            var comment = _context.Comments
                .Where(u => u.Id == id)
                .FirstOrDefault();
            return comment;
        }

        public async Task<bool> UpdateCommentAsync(Comment updatedComment)
        {
            _context.Entry(await _context.Comments
                .FirstOrDefaultAsync(x => x.Id == updatedComment.Id))
                .CurrentValues.SetValues(updatedComment);
            return await SaveChanges();
        }

        private async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
