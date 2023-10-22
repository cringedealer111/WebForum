using System;
using WebForum.Data.Models;
using WebForum.Data.repositories;

namespace WebForum.Service
{
    public class ForumService
    {
        private readonly IForumRepository _forumRepository;

        public ForumService(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository;
        }

        public IEnumerable<Forum> GetForums()
        {
            var forums = _forumRepository.GetAll();
            return forums;
        }

        public Forum GetForumById(int forumId)
        {
            var forum = _forumRepository.GetById(forumId);
            return forum;
        }
    }
}
