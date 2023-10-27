
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebForum.Data.Models;

namespace WebForum.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostReply> PostsReplies { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PostReply>(action =>
            {
                action.HasOne(reply => reply.Post).WithMany(post => post.Replies).OnDelete(DeleteBehavior.NoAction);
            }); 
            modelBuilder.Entity<Forum>(action=>
                action.HasMany(forum=>forum.Posts).WithOne(post=>post.Forum));
            
            modelBuilder.Entity<Post>(action =>
            {
                action.HasOne(post => post.Forum).WithMany(forum => forum.Posts);
            });

        }
    }
}