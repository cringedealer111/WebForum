using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Data.Models;

namespace WebForum.Data.repositories
{
    public interface IPostRepository
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();

        Task Add(Post post);
        Task Delete(int id);
        Task Update(Post post);
        IEnumerable<Post> GetByForumId(int forumId);

    }
}
