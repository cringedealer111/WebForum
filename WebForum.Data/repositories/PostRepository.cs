using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Data.Models;

namespace WebForum.Data.repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DbContextFactory _dbContextFactory;

        public PostRepository(DbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public Post GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Add(Post post)
        {
            throw new NotImplementedException();
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
            var context = _dbContextFactory.Create(typeof(PostRepository));
            var posts = context.Forums
                .Where(forum => forum.Id == id)
                .First().Posts;
            
            return posts;

        }
    }
}
