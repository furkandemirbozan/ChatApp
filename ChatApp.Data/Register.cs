using ChatApp.Data.Repositories;
using ChatApp.Data.Repositories.GroupRepository;
using ChatApp.Data.Repositories.MessageRepositories;
using ChatApp.Data.Repositories.UserRepositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Data
{
    public static class Register
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IMessageRepository,MessageRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IGroupRepository,GroupRepository>();
        }
    }
}
