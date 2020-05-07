using ItaLog.Data.Context;
using ItaLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ItaLog.Test.Fakes
{
    public static class ContextFake
    {
        public static ItaLogContext GetContext(string dataBaseName)
        {
            var options = new DbContextOptionsBuilder<ItaLogContext>()
                .UseInMemoryDatabase(dataBaseName)
                .Options;
            return new ItaLogContext(options);
        }

        public static ItaLogContext AddFakeLevels(this ItaLogContext context)
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

            var environments = new List<Environment>()
            {
                new Environment() {Id = 1, Description = "Teste_Environment_1"},
                new Environment() {Id = 2, Description = "Teste_Environment_2"},
                new Environment() {Id = 3, Description = "Teste_Environment_3"}
            };
            context.Environments.AddRange(environments);
            context.SaveChanges();

            foreach (var env in environments)
            {
                context.Entry<Environment>(env).State = EntityState.Detached;
            }


            return context;
        }
    }
}
