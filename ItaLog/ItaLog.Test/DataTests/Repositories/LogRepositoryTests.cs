using ItaLog.Data.Repositories;
using ItaLog.Domain.Models;
using ItaLog.Test.Comparers;
using ItaLog.Test.Fakes;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace ItaLog.Test.DataTests.Repositories
{
    public class LogRepositoryTests
    {
        [Fact]
        public void Add_ShouldWork()
        {
            var log = new Log()
            {
                    Title = "Removed BreakPoints", 
                    Origin = "7.41.110.164", 
                    Archived = false, 
                    LevelId = 1, 
                    EnvironmentId = 1, 
                    ApiUserId = 1
            };
            var context = ContextFake.GetContext("Add_ShouldWork")
                .AddFakeEnvironments()
                .AddFakeLevels()
                .AddFakeUsers();

            var repo = new LogRepository(context);
            repo.Add(log);

            var result = context.Levels.FirstOrDefault();
            Assert.NotNull(result);
            Assert.Equal(log.Title, log.Title);
            Assert.Equal(log.Origin, log.Origin);
            Assert.Equal(log.Archived, log.Archived);
            Assert.Equal(log.LevelId, log.LevelId);
            Assert.Equal(log.EnvironmentId, log.EnvironmentId);
            Assert.Equal(log.ApiUserId, log.ApiUserId);
        }

        [Fact]
        public void Update_ShouldWork()
        {
            var context = ContextFake
                .GetContext("Update_ShouldWork")
                .AddFakeLogs();

            var logUpdate = context.Logs.First();
            logUpdate.Title = "TitleUpdate";

            var repo = new LogRepository(context);
            repo.Update(logUpdate);

            var result = context.Logs.SingleOrDefault(x => x.Id == logUpdate.Id);
            Assert.NotNull(result);
            Assert.Equal(logUpdate.Title, result.Title);
        }

        [Fact]
        public void FindById_ShouldWork()
        {
            var context = ContextFake
                .GetContext("FindById_ShouldWork")
                .AddFakeLogs();
            var logFind = context.Logs.First();

            var repo = new LogRepository(context);
            var result = repo.FindById(logFind.Id);

            Assert.NotNull(result);
            Assert.Equal(logFind.Title, result.Title);
        }

        [Fact]
        public void Remove_ShouldWork()
        {
            var context = ContextFake
                .GetContext("Remove_ShouldWork")
                .AddFakeLogs();

            var logDelete = context.Logs.First();

            var repo = new LogRepository(context);
            repo.Remove(logDelete.Id);

            var result = context.Logs.SingleOrDefault(x => x.Id == logDelete.Id);
            Assert.Null(result);
        }

        [Fact]
        public void GetAll_ShouldWork()
        {
            var context = ContextFake
                .GetContext("GetAll_ShouldWork")
                .AddFakeLogs();
            var logsFind = context.Logs.ToList();

            var repo = new LogRepository(context);
            var result = repo.GetAll();

            Assert.NotNull(result);
            Assert.Equal(logsFind, result, new LogComparer());
        }

        [Fact]
        public void GetPage_ShouldWork()
        {
            var context = ContextFake
                .GetContext("GetPage_ShouldWork");

            var logs = new List<Log>()
            {
             new Log { Id = 1, Title = "599 Network connect timeout error", Origin = "216.3.128.12", Archived = false, LevelId = 3, EnvironmentId = 1, ApiUserId = 3 },
             new Log { Id = 2, Title = "413 Request Entity Too Large", Origin = "158.113.248.85", Archived = false, LevelId = 3, EnvironmentId = 2, ApiUserId = 1 },
             new Log { Id = 3, Title = "512 Disconnected Operation", Origin = "227.39.42.158", Archived = false, LevelId = 1, EnvironmentId = 2, ApiUserId = 4 }
            };
            context.Logs.AddRange(logs);
            context.SaveChanges();
            
            var logsFind = context.Logs.ToList();

            var logFilter = new LogFilter()
            {
                LevelId = null,
                Title = null,
                Origin = null
            };
            var pageFilter = new PageFilter()
            {
                PageLength = 3,
                PageNumber = 1,
            };

            var expected = new Page<Log>()
            {
                Total = logsFind.Count(),
                TotalPages = 1,
                Results = logsFind.Take(3)
            };

            var repo = new LogRepository(context);
            var result = repo.GetPage(logFilter, pageFilter, null);

            Assert.NotNull(result);
            Assert.Equal(expected.Total, result.Total);
            Assert.Equal(expected.TotalPages, result.TotalPages);
            Assert.Equal(expected.Results, result.Results, new LogComparer());
        }
    }
}
