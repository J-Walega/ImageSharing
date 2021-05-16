using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageSharing.Services
{
    public interface ICommentService
    {
        Task<bool> PostCommentAsync();
        Task<bool> DeleteCommentAsync();
        Task<bool> EditCommentAsync();
    }
}
