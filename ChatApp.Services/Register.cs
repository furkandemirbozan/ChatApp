using ChatApp.Services.Services.Groups;
using ChatApp.Services.Services.Messages;
using ChatApp.Services.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Services
{
    public static class Register
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IGroupSerivces, GroupServices>();
            services.AddScoped<IMessageServices, MessageServices>();
        }
    }
}
