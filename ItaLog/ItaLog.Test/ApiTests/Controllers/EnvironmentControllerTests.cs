using AutoMapper;
using ItaLog.Api.AutoMapper;
using ItaLog.Api.Controllers;
using ItaLog.Api.ViewModels;
using ItaLog.Api.ViewModels.Environment;
using ItaLog.Data.Repositories;
using ItaLog.Domain.Models;
using ItaLog.Test.Fakes;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Xunit;

namespace ItaLog.Test.ApiTests.Controllers
{
    public class EnvironmentControllerTests
    {
        private readonly IMapper _mapper;
        public EnvironmentControllerTests()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfig());
            });
            _mapper = configuration.CreateMapper();
        }

        [Fact]
        public void GetEnvironments_ShouldWork()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("GetEnvironments_ShouldWork")
                .AddFakeEnvironments();

            var repo = new EnvironmentRepository(context);

            var controller = new EnvironmentController(repo, _mapper);
            var pageFilter = new PageFilter();

            var result = controller.GetEnvironments(pageFilter);

            Assert.IsType<ActionResult<PageViewModel<EnvironmentViewModel>>>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<PageViewModel<EnvironmentViewModel>>(actionResult.Value);
        }

        [Fact]
        public void GetById_ShouldWork()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("GetById_ShouldWork")
                .AddFakeEnvironments();

            var repo = new EnvironmentRepository(context);

            var controller = new EnvironmentController(repo, _mapper);

            var result = controller.GetById(1);

            Assert.IsType<ActionResult<EnvironmentViewModel>>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<EnvironmentViewModel>(actionResult.Value);
        }

        [Fact]
        public void GetById_Notfound()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("GetById_Notfound")
                .AddFakeEnvironments();

            var repo = new EnvironmentRepository(context);

            var controller = new EnvironmentController(repo, _mapper);

            var result = controller.GetById(int.MaxValue);

            Assert.IsType<ActionResult<EnvironmentViewModel>>(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void Create_ShouldWork()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("Create_ShouldWork")
                .AddFakeEnvironments();

            var repo = new EnvironmentRepository(context);

            var controller = new EnvironmentController(repo, _mapper);
            var newEnvironment = new EnvironmentCreateViewModel()
            {
                Description = "New Environment"
            };

            var result = controller.Create(newEnvironment);
            Assert.IsType<ActionResult<EntityBase>>(result);
            var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var valueResult = Assert.IsType<EntityBase>(actionResult.Value);

            var actual = context.Environments.SingleOrDefault(x => x.Id == valueResult.Id);
            Assert.Equal(newEnvironment.Description, actual.Description);
        }

        [Fact]
        public void Update_ShouldWork()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("Update_ShouldWork")
                .AddFakeEnvironments();

            var repo = new EnvironmentRepository(context);

            var controller = new EnvironmentController(repo, _mapper);
            var updateEnvironment = new EnvironmentViewModel()
            {
                Id = 1,
                Description = "Update Environment"
            };

            var result = controller.Update(updateEnvironment.Id, updateEnvironment);
            var actionResult = Assert.IsType<NoContentResult>(result);

            var actual = context.Environments.SingleOrDefault(x => x.Id == updateEnvironment.Id);
            Assert.Equal(updateEnvironment.Description, actual.Description);
        }

        [Fact]
        public void Update_NotFoundIdEnvironment()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("Update_NotFoundIdEnvironment")
                .AddFakeEnvironments();

            var repo = new EnvironmentRepository(context);

            var controller = new EnvironmentController(repo, _mapper);
            var updateEnvironment = new EnvironmentViewModel()
            {
                Id = int.MaxValue,
                Description = "Update Environment"
            };

            var result = controller.Update(updateEnvironment.Id, updateEnvironment);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Update_BadRequestIdNotEqual()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("Update_BadRequestIdNotEqual")
                .AddFakeEnvironments();

            var repo = new EnvironmentRepository(context);

            var controller = new EnvironmentController(repo, _mapper);
            var updateEnvironment = new EnvironmentViewModel()
            {
                Id = 1,
                Description = "Update Environment"
            };

            var result = controller.Update(2, updateEnvironment);
            var actionResult = Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Delete_ShouldWork()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("Delete_ShouldWork")
                .AddFakeEnvironments();
            var repo = new EnvironmentRepository(context);

            var controller = new EnvironmentController(repo, _mapper);
            var deleteEnvironment = context.Environments.FirstOrDefault();

            var result = controller.Delete(deleteEnvironment.Id);
            var actionResult = Assert.IsType<NoContentResult>(result);

            var actual = context.Environments.SingleOrDefault(x => x.Id == deleteEnvironment.Id);
            Assert.Null(actual);
        }

        [Fact]
        public void Delete_NotFoundIdEnvironment()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("Delete_NotFoundIdEnvironment")
                .AddFakeEnvironments();

            var repo = new EnvironmentRepository(context);

            var controller = new EnvironmentController(repo, _mapper);

            var result = controller.Delete(int.MaxValue);
            var actionResult = Assert.IsType<NotFoundResult>(result);
        }
    }
}
