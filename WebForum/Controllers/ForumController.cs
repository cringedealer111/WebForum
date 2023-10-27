using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebForum.Models;
using WebForum.Service;

namespace WebForum.Controllers
{
    public class ForumController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ForumService _forumService;
        private readonly PostService _postService;

        public ForumController(ForumService forumService, PostService postService, IMapper mapper)
        {
            _mapper = mapper;
            _postService = postService;
            _forumService = forumService;
        }

        public IActionResult Index()
        {
            var forums = _forumService.GetForums()
                .Select(forum => _mapper.Map<ForumListingModel>(forum));

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

            var postListings = posts.Select(post => _mapper.Map<PostListingModel>(post));

            var model = new ForumTopicModel
            {
                Posts = postListings,
                Forum = _mapper.Map<ForumListingModel>(forum)
            };

            return View(model);
        }
    }
}
