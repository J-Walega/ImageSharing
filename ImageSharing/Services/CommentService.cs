using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSharing.Contacts.V1.Requests;
using ImageSharing.Domain;
using ImageSharing.Repo.Interfaces;

namespace ImageSharing.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepo _commentRepo;

        public CommentService(ICommentRepo commentRepo)
        {
            _commentRepo = commentRepo;
        }

        public async Task<bool> PostCommentAsync(string username, PostCommentRequest request)
        {
            var comment = new Comment()
            {
                Username = username,
                ImageId = request.ImageId,
                Content = request.Content
            };

           return await _commentRepo.AddCommentAsync(comment);
        }

        public async Task<List<Comment>> GetImageCommentsAsync(Guid imageId)
        {
            var comments = await _commentRepo.GetCommentsByImageIdAsync(imageId);

            var response = new List<Comment>();

            foreach(var comment in comments)
            {
                response.Add(comment);
            }
            return response;
        }

        public async Task<bool> EditCommentAsync(Guid commentId, string content)
        {
            var comment = _commentRepo.GetCommentById(commentId);

            var updatedComment = new Comment()
            {
                Id = commentId,
                Username = comment.Username,
                ImageId = comment.ImageId,
                Content = content
            };
           var response = await _commentRepo.UpdateCommentAsync(updatedComment);
            return response;
        }

        public Task<bool> DeleteCommentAsync()
        {
            throw new NotImplementedException();
        }
    }
}
