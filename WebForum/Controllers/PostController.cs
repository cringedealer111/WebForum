using Microsoft.AspNetCore.Mvc;
using WebForum.Models;
using WebForum.Service;

namespace WebForum.Controllers
{
    public class PostController : Controller
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }
        public IActionResult Index(int id)
        {
            var post = _postService.GetPostById(id);
            var replies = PostReplyModel.BuildPostReplies(post.Replies);

            var model = new PostIndexModel
            {
                Id=post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorImageUrl = post.User.ProfileImageUrl,
                AuthorRating = post.User.Rating,
                Created = post.Created,
                PostContent = post.Content,
                Replies = replies
            };

            return View(model);
        }
    }
}
