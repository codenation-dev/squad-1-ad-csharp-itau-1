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

            return context;
        }
    }
}
