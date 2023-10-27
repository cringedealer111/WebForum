using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using WebForum.Data.Repositories;

namespace WebForum.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(
                options =>
                {
                    options.UseSqlServer(connectionString);
                }
                
            );
            services.AddScoped<IForumRepository, ForumRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }
    }
}
