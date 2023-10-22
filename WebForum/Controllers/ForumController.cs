using Microsoft.AspNetCore.Mvc;
using WebForum.Data.repositories;
using WebForum.Models;
using WebForum.Service;

namespace WebForum.Controllers
{
    public class ForumController : Controller
    {
        private readonly ForumService _forumService;
        private readonly PostService _postService;
        public ForumController(ForumService forumService, PostService postService)
        {
            _postService = postService;
            _forumService = forumService;
        }
        public IActionResult Index()
        {
            var forums = _forumService.GetForums()
                .Select(forum => new ForumListingModel
                {
                    Id=forum.Id,
                    Title=forum.Title,
                    Description = forum.Description,
                    ImageUrl = forum.ImageUrl
                });

            var model = new ForumIndexModel
            {
                ForumList = forums
            };

            return View(model);
            

        }
        public IActionResult Topic(int id)
        {
            var forum = _forumService.GetForumById(id);
            var posts = forum.Posts;

            var postListings = posts.Select(post => new PostListingModel
            {
                Id = post.Id,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorRating = post.User.Rating,
                Title = post.Title,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Forum = ForumListingModel.BuildForumListingModel(post)
                
            });

            var model = new ForumTopicModel
            {
                Posts = postListings,
                Forum = ForumListingModel.BuildForumListingModel(forum)
            };

            return View(model);
        }
    }
}
