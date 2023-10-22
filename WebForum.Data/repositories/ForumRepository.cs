using Microsoft.EntityFrameworkCore;
using WebForum.Data.Models;

namespace WebForum.Data.repositories
{
    public class ForumRepository : IForumRepository
    {
        private readonly DbContextFactory _dbContextFactory;

        public ForumRepository(DbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public Forum GetById(int id)
        {
            var context = _dbContextFactory.Create(typeof(ForumRepository));
            var forum = context.Forums.Where(f => f.Id == id)
                .Include(f => f.Posts).ThenInclude(p => p.User)
                .Include(f => f.Posts).ThenInclude(p => p.Replies).ThenInclude(r => r.User)
                .FirstOrDefault();

            return forum;
        }

        public IEnumerable<Forum> GetAll()
        {
            var context = _dbContextFactory.Create(typeof(ForumRepository));
            return context.Forums
                .Include(forum => forum.Posts);
        }

        public IEnumerable<ApplicationUser> GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        public Task Create(Forum forum)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int forumId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateForumTitle(int forumId, string title)
        {
            throw new NotImplementedException();
        }

        public Task UpdateForumDescription(int forumId, string description)
        {
            throw new NotImplementedException();
        }
    }
}
