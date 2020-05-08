using ItaLog.Data.Context;
using ItaLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System;

namespace ItaLog.Test.Fakes
{
    public class ContextFake
    {
        public ItaLogContext GetContext(string dataBaseName)
        {
            var options = new DbContextOptionsBuilder<ItaLogContext>()
                .UseInMemoryDatabase(dataBaseName)
                .Options;
            return new ItaLogContext(options);
        }
    }

    public static class ContextFakeExtensions
    { 
        public static  ItaLogContext AddFakeLevels(this ItaLogContext context)
        {
            if (context.Levels.Any()) return context;

            var levels = new List<Level>()
            {
                new Level() {Id = 1, Description = "Teste_1"},
                new Level() {Id = 2, Description = "Teste_2"},
                new Level() {Id = 3, Description = "Teste_3"}
            };

            context.Levels.AddRange(levels);
            context.SaveChanges();

            foreach(var level in levels)
            {
                context.Entry<Level>(level).State = EntityState.Detached;
            }

            return context;
        }

        public static ItaLogContext AddFakeEnvironments(this ItaLogContext context)
        {
            if (context.Environments.Any()) return context;

            var environments = new List<Domain.Models.Environment>()
            {
                new Domain.Models.Environment() {Id = 1, Description = "Teste_Environment_1"},
                new Domain.Models.Environment() {Id = 2, Description = "Teste_Environment_2"},
                new Domain.Models.Environment() {Id = 3, Description = "Teste_Environment_3"}
            };
            context.Environments.AddRange(environments);
            context.SaveChanges();

            foreach (var env in environments)
            {
                context.Entry<Domain.Models.Environment>(env).State = EntityState.Detached;
            }

            return context;
        }

        public static ItaLogContext AddFakeLogs(this ItaLogContext context)
        {
            if (context.Logs.Any()) return context;

            var logs = new List<Log>()
            {
             new Log { Id = 1, Title = "599 Network connect timeout error", Origin = "216.3.128.12", Archived = false, LevelId = 3, EnvironmentId = 1, ApiUserId = 1 },
             new Log { Id = 2, Title = "413 Request Entity Too Large", Origin = "158.113.248.85", Archived = false, LevelId = 3, EnvironmentId = 2, ApiUserId = 1 },
             new Log { Id = 3, Title = "512 Disconnected Operation", Origin = "227.39.42.158", Archived = false, LevelId = 1, EnvironmentId = 2, ApiUserId = 2 }             
            };

            context.Logs.AddRange(logs);
            context.SaveChanges();

            foreach (var log in logs)
            {
                context.Entry<Log>(log).State = EntityState.Detached;
            }

            return context;
        }

        public static ItaLogContext AddFakeEvents(this ItaLogContext context)
        {
            if (context.Events.Any()) return context;

            var events = new List<Event>()
            {
              new Event { Id = 1, Detail = "Client exceeded the maximum timeout value of 60 seconds", ErrorDate = DateTime.Parse("10-03-2019"), LogId = 1 },
              new Event { Id = 2, Detail = "Maximum upload size of 25MB was exceeded", ErrorDate = DateTime.Parse("12-08-2019"), LogId = 2 },
              new Event { Id = 3, Detail = "Maximum upload size of 25MB was exceededs", ErrorDate = DateTime.Parse("22-11-2019"), LogId = 2 },
              new Event { Id = 4, Detail = "Maximum upload size of 25MB was exceededs", ErrorDate = DateTime.Parse("22-11-2019"), LogId = 3 }
        };

            context.Events.AddRange(events);
            context.SaveChanges();

            foreach (var event_ in events)
            {
                context.Entry<Event>(event_).State = EntityState.Detached;
            }

            return context;
        }

        public static ItaLogContext AddFakeUsers(this ItaLogContext context)
        {
            if (context.Users.Any()) return context;

            var users = new List<User>()
            {
                new User
                {
                Id = 1,
                UserToken = Guid.NewGuid(),
                Name = "Admin",
                UserName = "admin@contato.com",
                NormalizedUserName = "ADMIN@CONTATO.COM",
                Email = "admin@contato.com",
                EmailConfirmed = true,
                Password = "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==",
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
                },

                new User
                {
                Id = 2,
                UserToken = Guid.NewGuid(),
                Name = "Itau",
                UserName = "itau@contato.com",
                NormalizedUserName = "ITAU@CONTATO.COM",
                Email = "itau@contato.com",
                EmailConfirmed = true,
                Password = "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==",
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            foreach (var user in users)
            {
                context.Entry<User>(user).State = EntityState.Detached;
            }

            return context;
        }
    }
}
