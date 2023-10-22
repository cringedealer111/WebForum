using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebForum.Data.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public Forum Forum { get; set; }
        public ApplicationUser User { get; set; }
        public IEnumerable<PostReply> Replies { get; set; }

    }
}
