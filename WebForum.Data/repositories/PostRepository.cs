using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using WebForum.Data.Models;

namespace WebForum.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Post GetById(int id)
        {

            var post =  _context.Posts.Where(post => post.Id == id)
                .Include(post => post.User)
                .Include(post => post.Replies).ThenInclude(reply => reply.User)
                .Include(post => post.Forum)
                .FirstOrDefault();
            return post;
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Add(Post post)
        {
            _context.Posts.AddAsync(post);

            await _context.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Post post)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetByForumId(int id)
        {
            var posts = _context.Forums
                .Where(forum => forum.Id == id)
                .First().Posts;
            
            return posts;

        }
    }
}
