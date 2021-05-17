using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSharing.Domain;

namespace ImageSharing.Repo.Interfaces
{
    public interface ICommentRepo
    {
        public Task<bool> AddCommentAsync(Comment comment);
        public Task<IEnumerable<Comment>> GetCommentsByImageIdAsync(Guid imageId);
        public Task<bool> UpdateCommentAsync(Comment updatedComment);
        public Comment GetCommentById(Guid id);
    }
}
