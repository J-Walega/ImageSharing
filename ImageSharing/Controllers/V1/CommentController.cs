using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSharing.Contacts.V1;
using ImageSharing.Contacts.V1.Requests;
using ImageSharing.Extensions;
using ImageSharing.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ImageSharing.Controllers.V1
{
    public class CommentController : Controller
    {
        private ICommentService _service;
        public CommentController(ICommentService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost(ApiRoutes.Comments.Post)]
        public async Task<IActionResult> PostCommentAsync([FromBody] PostCommentRequest request )
        {
            var username = HttpContext.GetUsername();
            var respose = await  _service.PostCommentAsync(username, request);
            return Ok(respose);
        }

        [HttpGet(ApiRoutes.Comments.GetImageComments)]
        public async Task<IActionResult> GetImageCommentsAsync([FromRoute] Guid imageId)
        {
            var response = await _service.GetImageCommentsAsync(imageId);
            return Ok(response);
        }

        [Authorize]
        [HttpPatch(ApiRoutes.Comments.Patch)]
        public async Task<IActionResult> PatchCommentAsync([FromRoute] Guid commentId, [FromBody] UpdateCommentRequest conetent)
        {
            var response = await _service.EditCommentAsync(commentId, conetent.Content);
            if (response == true)
            {
                return Ok();
            }
            else
                return BadRequest();
        }
    }
}
