using ItaLog.Data.Repositories;
using ItaLog.Domain.Models;
using ItaLog.Test.Comparers;
using ItaLog.Test.Fakes;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace ItaLog.Test.DataTests.Repositories
{
    public class LevelRepositoryTests
    {
        [Fact]
        public void Add_ShouldWork()
        {
            var level = new Level()
            {
                Description = "Critical"
            };
            var context = ContextFake.GetContext("Add_ShouldWork");
            var repo = new LevelRepository(context);
            repo.Add(level);

            var result = context.Levels.FirstOrDefault();
            Assert.NotNull(result);
            Assert.Equal(level.Description, result.Description);
        }

        [Fact]
        public void Update_ShouldWork()
        {
            var context = ContextFake
                .GetContext("Update_ShouldWork")
                .AddFakeLevels();

            var levelUpdate = context.Levels.Skip(1).First();
            levelUpdate.Description = "DescriptionUpdate";

            var repo = new LevelRepository(context);
            repo.Update(levelUpdate);

            var result = context.Levels.SingleOrDefault(x => x.Id == levelUpdate.Id);
            Assert.NotNull(result);
            Assert.Equal(levelUpdate.Description, result.Description);
        }

        [Fact]
        public void FindById_ShouldWork()
        {
            var context = ContextFake
                .GetContext("FindById_ShouldWork")
                .AddFakeLevels();
            var levelFind = context.Levels.Skip(1).First();

            var repo = new LevelRepository(context);
            var result = repo.FindById(levelFind.Id);

            Assert.NotNull(result);
            Assert.Equal(levelFind.Description, result.Description);
        }

        [Fact]
        public void Remove_ShouldWork()
        {
            var context = ContextFake
                .GetContext("Remove_ShouldWork")
                .AddFakeLevels();

            var levelDelete = context.Levels.Skip(1).First();

            var repo = new LevelRepository(context);
            repo.Remove(levelDelete.Id);

            var result = context.Levels.SingleOrDefault(x => x.Id == levelDelete.Id);
            Assert.Null(result);
        }

        [Fact]
        public void GetAll_ShouldWork()
        {
            var context = ContextFake
                .GetContext("GetAll_ShouldWork")
                .AddFakeLevels();
            var levelsFind = context.Levels.ToList();

            var repo = new LevelRepository(context);
            var result = repo.GetAll();

            Assert.NotNull(result);
            Assert.Equal(levelsFind, result, new LevelComparer());
        }

        [Fact]
        public void GetPage_ShouldWork()
        {
            var context = ContextFake
                .GetContext("GetPage_ShouldWork");

            var levels = new List<Level>()
            {
                new Level() {Id = 1, Description = "Teste_1"},
                new Level() {Id = 2, Description = "Teste_2"},
                new Level() {Id = 3, Description = "Teste_3"}
            };
            context.Levels.AddRange(levels);
            context.SaveChanges();


            var levelsFind = context.Levels.ToList();
            var pageFilter = new PageFilter()
            {
                PageLength = 2,
                PageNumber = 1,
            };
            var expected = new Page<Level>()
            {
                Total = levelsFind.Count(),
                TotalPages = 2,
                Results = levelsFind.Take(2)
            };

            var repo = new LevelRepository(context);
            var result = repo.GetPage(pageFilter);

            Assert.NotNull(result);
            Assert.Equal(expected.Total, result.Total);
            Assert.Equal(expected.TotalPages, result.TotalPages);
            Assert.Equal(expected.Results, result.Results, new LevelComparer());
        }
    }
}
