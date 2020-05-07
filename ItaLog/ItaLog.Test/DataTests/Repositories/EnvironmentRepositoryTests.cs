using ItaLog.Data.Repositories;
using ItaLog.Domain.Models;
using ItaLog.Test.Comparers;
using ItaLog.Test.Fakes;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace ItaLog.Test.DataTests.Repositories
{
    public class EnvironmentRepositoryTests
    {
        [Fact]
        public void Add_ShouldWork()
        {
            var environment = new Environment()
            {
                Description = "Critical"
            };
            var context = ContextFake.GetContext("Add_ShouldWork");
            var repo = new EnvironmentRepository(context);
            repo.Add(environment);

            var result = context.Environments.FirstOrDefault();
            Assert.NotNull(result);
            Assert.Equal(environment.Description, result.Description);
        }

        [Fact]
        public void Update_ShouldWork()
        {
            var context = ContextFake
                .GetContext("Update_ShouldWork")
                .AddFakeEnvironments();

            var environmentUpdate = context.Environments.Skip(1).First();
            environmentUpdate.Description = "DescriptionUpdate";

            var repo = new EnvironmentRepository(context);
            repo.Update(environmentUpdate);

            var result = context.Environments.SingleOrDefault(x => x.Id == environmentUpdate.Id);
            Assert.NotNull(result);
            Assert.Equal(environmentUpdate.Description, result.Description);
        }

        [Fact]
        public void FindById_ShouldWork()
        {
            var context = ContextFake
                .GetContext("FindById_ShouldWork")
                .AddFakeEnvironments();
            var environmentFind = context.Environments.Skip(1).First();

            var repo = new EnvironmentRepository(context);
            var result = repo.FindById(environmentFind.Id);

            Assert.NotNull(result);
            Assert.Equal(environmentFind.Description, result.Description);
        }

        [Fact]
        public void Remove_ShouldWork()
        {
            var context = ContextFake
                .GetContext("Remove_ShouldWork")
                .AddFakeEnvironments();

            var environmentDelete = context.Environments.Skip(1).First();

            var repo = new EnvironmentRepository(context);
            repo.Remove(environmentDelete.Id);

            var result = context.Environments.SingleOrDefault(x => x.Id == environmentDelete.Id);
            Assert.Null(result);
        }

        [Fact]
        public void GetAll_ShouldWork()
        {
            var context = ContextFake
                .GetContext("GetAll_ShouldWork")
                .AddFakeEnvironments();
            var environmentsFind = context.Environments.ToList();

            var repo = new EnvironmentRepository(context);
            var result = repo.GetAll();

            Assert.NotNull(result);
            Assert.Equal(environmentsFind, result, new EnvironmentComparer());
        }

        [Fact]
        public void GetPage_ShouldWork()
        {
            var context = ContextFake
                .GetContext("GetPage_ShouldWork");

            var environments = new List<Environment>()
            {
                new Environment() {Id = 1, Description = "Teste_1"},
                new Environment() {Id = 2, Description = "Teste_2"},
                new Environment() {Id = 3, Description = "Teste_3"}
            };
            context.Environments.AddRange(environments);
            context.SaveChanges();


            var environmentsFind = context.Environments.ToList();
            var pageFilter = new PageFilter()
            {
                PageLength = 2,
                PageNumber = 1,
            };
            var expected = new Page<Environment>()
            {
                Total = environmentsFind.Count(),
                TotalPages = 2,
                Results = environmentsFind.Take(2)
            };

            var repo = new EnvironmentRepository(context);
            var result = repo.GetPage(pageFilter);

            Assert.NotNull(result);
            Assert.Equal(expected.Total, result.Total);
            Assert.Equal(expected.TotalPages, result.TotalPages);
            Assert.Equal(expected.Results, result.Results, new EnvironmentComparer());
        }
    }
}
