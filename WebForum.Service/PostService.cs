using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Data.Models;
using WebForum.Data.Repositories;


namespace WebForum.Service
{
    public class PostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IEnumerable<Post> GetPostsByForumId(int id)
        {
            var posts = _postRepository.GetByForumId(id);
            return posts;
        }

        public Post GetPostById(int id)
        {
            var post = _postRepository.GetById(id);
            return post;
        }

        public async Task Add(Post post)
        {
            await _postRepository.Add(post);
        }

    }
}
