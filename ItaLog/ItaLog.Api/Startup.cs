using ItaLog.Api.Configurations;
using ItaLog.Api.AutoMapper;
using ItaLog.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using ItaLog.Data.Seeds;
using ItaLog.CrossCutting.Services;

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
            services.AddControllers();

            services.AddDbContext<ItaLogContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Database")));            

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            services.AddAutoMapper(typeof(AutoMapperConfig));

            // Dependency Injection Abstraction
            services.AddDependencyInjectionSetup();

            // Seeds
            services.AddSeedSetup();

            // Api Versioning Config
            services.AddVersioningSetup();

            // ASP.NET Identity Settings & JWT
            services.AddIdentitySetup(Configuration);

            // Swagger Config
            services.AddSwaggerSetup();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserSeed userSeed, RoleSeed roleSeed, LevelSeed levelSeed, EnvironmentSeed environmentSeed, LogSeed logSeed, EventSeed eventSeed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                userSeed.Populate();
                roleSeed.Populate();
                levelSeed.Populate();
                environmentSeed.Populate();
                logSeed.Populate();
                eventSeed.Populate();
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
