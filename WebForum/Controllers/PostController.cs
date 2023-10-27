using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebForum.Data.Models;
using WebForum.Models;
using WebForum.Service;

namespace WebForum.Controllers
{
    public class PostController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly PostService _postService;
        private readonly ForumService _forumService;
        private readonly IMapper _mapper;

        public PostController(PostService postService, ForumService forumService, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
            _forumService = forumService;
            _postService = postService;
        }
        public IActionResult Index(int id)
        {
            var post = _postService.GetPostById(id);

            var model = _mapper.Map<PostIndexModel>(post);

            return View(model);
        }

        public IActionResult Create(int id)
        {
            var forum = _forumService.GetForumById(id);

            var model = new NewPostModel
            {
                ForumName = forum.Title,
                ForumId = forum.Id,
                ForumImageUrl = forum.ImageUrl,
                AuthorName = User.Identity.Name,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(NewPostModel model)
        {
            var forum = _forumService.GetForumById(model.ForumId);
            var userId = _userManager.GetUserId(User);
            var user =  await _userManager.FindByIdAsync(userId);
            var post = new Post
            {
                Title = model.Title,
                Content = model.Content,
                Created = DateTime.Now,
                User = user,
                Forum = forum
            };

             await _postService.Add(post);
            
            return RedirectToAction("Index", "Post", new { id = post.Id });
        }
    }
}
