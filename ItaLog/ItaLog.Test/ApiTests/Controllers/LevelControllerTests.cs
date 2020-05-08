using AutoMapper;
using ItaLog.Api.AutoMapper;
using ItaLog.Api.Controllers;
using ItaLog.Api.ViewModels;
using ItaLog.Api.ViewModels.Level;
using ItaLog.Data.Repositories;
using ItaLog.Domain.Models;
using ItaLog.Test.Fakes;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Xunit;

namespace ItaLog.Test.ApiTests.Controllers
{
    public class LevelControllerTests
    {
        private readonly IMapper _mapper;
        public LevelControllerTests()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfig());
            });
            _mapper = configuration.CreateMapper();
        }

        [Fact]
        public void GetLevels_ShouldWork()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("GetLevels_ShouldWork");
            context = contextFake.AddFakeLevels(context);

            var repo = new LevelRepository(context);

            var controller = new LevelController(repo, _mapper);
            var pageFilter = new PageFilter();

            var result = controller.GetLevels(pageFilter);

            Assert.IsType<ActionResult<PageViewModel<LevelViewModel>>>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<PageViewModel<LevelViewModel>>(actionResult.Value);
        }

        [Fact]
        public void GetById_ShouldWork()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("GetById_ShouldWork");
            context = contextFake.AddFakeLevels(context);

            var repo = new LevelRepository(context);

            var controller = new LevelController(repo, _mapper);

            var result = controller.GetById(1);

            Assert.IsType<ActionResult<LevelViewModel>>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<LevelViewModel>(actionResult.Value);
        }

        [Fact]
        public void GetById_Notfound()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("GetById_Notfound");
            context = contextFake.AddFakeLevels(context);

            var repo = new LevelRepository(context);

            var controller = new LevelController(repo, _mapper);

            var result = controller.GetById(int.MaxValue);

            Assert.IsType<ActionResult<LevelViewModel>>(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void Create_ShouldWork()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("Create_ShouldWork");
            context = contextFake.AddFakeLevels(context);

            var repo = new LevelRepository(context);

            var controller = new LevelController(repo, _mapper);
            var newLevel = new LevelCreateViewModel()
            {
                Description = "New Level"
            };

            var result = controller.Create(newLevel);
            Assert.IsType<ActionResult<EntityBase>>(result);
            var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var valueResult = Assert.IsType<EntityBase>(actionResult.Value);

            var actual = context.Levels.SingleOrDefault(x => x.Id == valueResult.Id);
            Assert.Equal(newLevel.Description, actual.Description);
        }

        [Fact]
        public void Update_ShouldWork()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("Update_ShouldWork");
            context = contextFake.AddFakeLevels(context);

            var repo = new LevelRepository(context);

            var controller = new LevelController(repo, _mapper);
            var updateLevel = new LevelViewModel()
            {
                Id = 1,
                Description = "Update Level"
            };

            var result = controller.Update(updateLevel.Id, updateLevel);
            var actionResult = Assert.IsType<NoContentResult>(result);

            var actual = context.Levels.SingleOrDefault(x => x.Id == updateLevel.Id);
            Assert.Equal(updateLevel.Description, actual.Description);
        }

        [Fact]
        public void Update_NotFoundIdLevel()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("Update_NotFoundIdLevel");
            context = contextFake.AddFakeLevels(context);

            var repo = new LevelRepository(context);

            var controller = new LevelController(repo, _mapper);
            var updateLevel = new LevelViewModel()
            {
                Id = int.MaxValue,
                Description = "Update Level"
            };

            var result = controller.Update(updateLevel.Id, updateLevel);
            var actionResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Update_BadRequestIdNotEqual()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("Update_BadRequestIdNotEqual");
            context = contextFake.AddFakeLevels(context);

            var repo = new LevelRepository(context);

            var controller = new LevelController(repo, _mapper);
            var updateLevel = new LevelViewModel()
            {
                Id = 1,
                Description = "Update Level"
            };

            var result = controller.Update(2, updateLevel);
            var actionResult = Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Delete_ShouldWork()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("Delete_ShouldWork");
            context = contextFake.AddFakeLevels(context);

            var repo = new LevelRepository(context);

            var controller = new LevelController(repo, _mapper);
            var deleteLevel = context.Levels.FirstOrDefault();

            var result = controller.Delete(deleteLevel.Id);
            var actionResult = Assert.IsType<NoContentResult>(result);

            var actual = context.Levels.SingleOrDefault(x => x.Id == deleteLevel.Id);
            Assert.Null(actual);
        }

        [Fact]
        public void Delete_NotFoundIdLevel()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("Delete_NotFoundIdLevel");
            context = contextFake.AddFakeLevels(context);

            var repo = new LevelRepository(context);

            var controller = new LevelController(repo, _mapper);

            var result = controller.Delete(int.MaxValue);
            var actionResult = Assert.IsType<NotFoundResult>(result);
        }
    }
}
