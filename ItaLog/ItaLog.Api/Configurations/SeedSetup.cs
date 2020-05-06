using ItaLog.Data.Seeds;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ItaLog.Api.Configurations
{
    public static class SeedSetup
    {
        public static void AddSeedSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<UserSeed>();
            services.AddScoped<RoleSeed>();
            services.AddScoped<LevelSeed>();
            services.AddScoped<EnvironmentSeed>();
            services.AddScoped<LogSeed>();
            services.AddScoped<EventSeed>();
        }
    }
}
