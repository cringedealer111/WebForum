using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace WebForum.Data
{
    public class DbContextFactory
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public DbContextFactory(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public ApplicationDbContext Create(Type repositoryType)
        {
            var services = httpContextAccessor.HttpContext.RequestServices;

            var dbContexts = services.GetService<Dictionary<Type, ApplicationDbContext>>();
            if (!dbContexts.ContainsKey(repositoryType))
                dbContexts[repositoryType] = services.GetService<ApplicationDbContext>();

            return dbContexts[repositoryType];
        }
    }
}
