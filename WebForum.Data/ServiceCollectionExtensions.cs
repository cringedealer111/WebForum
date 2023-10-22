using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using WebForum.Data.repositories;

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
                },
                ServiceLifetime.Transient
            );
            services.AddScoped<Dictionary<Type, ApplicationDbContext>>();
            services.AddSingleton<DbContextFactory>();
            services.AddSingleton<IForumRepository, ForumRepository>();
            services.AddSingleton<IPostRepository, PostRepository>();

            return services;
        }
    }
}
