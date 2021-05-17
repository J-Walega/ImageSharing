using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSharing.Contacts.V1.Requests;
using ImageSharing.Domain;

namespace ImageSharing.Services
{
    public interface ICommentService
    {
        Task<bool> PostCommentAsync(string username, PostCommentRequest request);
        Task<List<Comment>> GetImageCommentsAsync(Guid imageId);
        Task<bool> DeleteCommentAsync();
        Task<bool> EditCommentAsync(Guid commentId, string content);
    }
}
