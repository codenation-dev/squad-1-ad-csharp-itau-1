using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace ItaLog.Api.Configurations
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ItaLog",
                    Version = "v1",
                    Description = "ItaLog API Swagger surface",
                    TermsOfService = new Uri("https://github.com/codenation-dev/squad-1-ad-csharp-itau-1/wiki/Terms-Of-Service"),
                    Contact = new OpenApiContact
                    {
                        Name = "ItaLog",
                        Email = "italogregister@gmail.com",
                        Url = new Uri("https://github.com/codenation-dev/squad-1-ad-csharp-itau-1"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use MIT License",
                        Url = new Uri("https://github.com/codenation-dev/squad-1-ad-csharp-itau-1/blob/master/LICENSE"),
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { "" }
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ItaLog");
            });
        }
    }
}
