using ItaLog.Api.Configurations;
using ItaLog.Api.Repository;
using ItaLog.Application.App;
using ItaLog.Application.AutoMapper;
using ItaLog.Application.Interface;
using ItaLog.Data.Context;
using ItaLog.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using ItaLog.Data.Repositories;
using ItaLog.Domain.Models;
using Microsoft.AspNetCore.Identity;
using ItaLog.Data.Store;

namespace ItaLog.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ItaLogContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Database")));
            services.AddScoped<IApiUserRepository, ApiUserRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<ILevelRepository, LevelRepository>();
            services.AddScoped<IEnvironmentRepository, EnvironmentRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IApiRoleRepository, RoleRepository>();
            services.AddScoped<IApiUserRoleRepository, UserRoleRepository>();

            services.AddScoped<IApiUserApplication, ApiUserApplication>();
            services.AddScoped<ILogApplication, LogApplication>();
            services.AddScoped<ILevelApplication, LevelApplication>();
            services.AddScoped<IEnvironmentApplication, EnvironmentApplication>();

            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.AddControllers();

            services.AddTransient<IUserStore<ApiUser>, ApiUserStore>();
            services.AddTransient<IRoleStore<ApiRole>, ApiRoleStore>();

            // ASP.NET Identity Settings & JWT
            services.AddIdentitySetup(Configuration);

            // Swagger Config
            services.AddSwaggerSetup();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerSetup();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
