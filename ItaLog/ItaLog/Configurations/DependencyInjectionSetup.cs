using ItaLog.Application.Services;
using ItaLog.Data.Repositories;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ItaLog.Api.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<ILevelRepository, LevelRepository>();
            services.AddScoped<IEnvironmentRepository, EnvironmentRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            
            services.AddTransient<IUserStore<User>, UserRepository>();
            services.AddTransient<IRoleStore<Role>, RoleRepository>();

            services.AddTransient<IEmailSender, EmailSender>();
        }
    }
}
