using AutoMapper;
using ItaLog.Api.AutoMapper;
using ItaLog.Api.Controllers;
using ItaLog.Api.ViewModels;
using ItaLog.Api.ViewModels.Environment;
using ItaLog.Api.ViewModels.Log;
using ItaLog.Data.Repositories;
using ItaLog.Domain.Models;
using ItaLog.Test.Fakes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Linq;
using System.Security.Claims;
using Xunit;

namespace ItaLog.Test.ApiTests.Controllers
{
    public class LogsControllerTests
    {
        private readonly ContextFake _contextFake;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public LogsControllerTests()
        {
            _contextFake = new ContextFake("LogsController");

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfig());
            });
            _mapper = configuration.CreateMapper();
            var moqUserManager = new Mock<UserManager<User>>(
                    new Mock<IUserStore<User>>().Object,
                    new Mock<IOptions<IdentityOptions>>().Object,
                    new Mock<IPasswordHasher<User>>().Object,
                    new IUserValidator<User>[0],
                    new IPasswordValidator<User>[0],
                    new Mock<ILookupNormalizer>().Object,
                    new Mock<IdentityErrorDescriber>().Object,
                    new Mock<IServiceProvider>().Object,
                    new Mock<ILogger<UserManager<User>>>().Object);
            moqUserManager.Setup(m => m.GetUserId(null)).Returns("1");
            _userManager = moqUserManager.Object;
        }

        [Fact]
        public void GetLogs_ShouldWork()
        {
            var context = _contextFake.GetContext("GetLogs_ShouldWork")
                .AddFakeEnvironments()
                .AddFakeLevels()
                .AddFakeUsers()
                .AddFakeLogs()
                .AddFakeEvents();

            var repo = new LogRepository(context);

            var controller = new LogsController(repo, _mapper, _userManager);
            var pageFilter = new PageFilter();
            var logFilter = new LogFilter();


            var result = controller.GetLogs(pageFilter, logFilter, null);


            Assert.IsType<ActionResult<PageViewModel<LogItemPageViewModel>>>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<PageViewModel<LogItemPageViewModel>>(actionResult.Value);
        }

        [Fact]
        public void GetById_ShouldWork()
        {
            var context = _contextFake.GetContext("GetById_ShouldWork")
                .AddFakeEnvironments()
                .AddFakeLevels()
                .AddFakeUsers()
                .AddFakeLogs()
                .AddFakeEvents();

            var repo = new LogRepository(context);
            
            var controller = new LogsController(repo, _mapper, _userManager);

            var result = controller.GetById(1);

            Assert.IsType<ActionResult<LogViewModel>>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<LogViewModel>(actionResult.Value);
        }

        [Fact]
        public void GetById_Notfound()
        {
            var context = _contextFake.GetContext("GetById_Notfound")
                .AddFakeEnvironments()
                .AddFakeLevels()
                .AddFakeUsers()
                .AddFakeLogs()
                .AddFakeEvents();

            var repo = new LogRepository(context);

            var controller = new LogsController(repo, _mapper, _userManager);

            var result = controller.GetById(int.MaxValue);

            Assert.IsType<ActionResult<LogViewModel>>(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void Create_ShouldWork()
        {
            var context = _contextFake.GetContext("Create_ShouldWork")
                .AddFakeEnvironments()
                .AddFakeLevels()
                .AddFakeUsers()
                .AddFakeLogs()
                .AddFakeEvents();

            var repo = new LogRepository(context);

            var controller = new LogsController(repo, _mapper, _userManager);
            var newLog = new LogEventViewModel()
            {
                Title = "599 Network connect timeout error",
                Detail = "Response took more than 30 seconds",
                Origin = "216.3.128.12",
                ErrorDate = DateTime.Parse("10-03-10"),
                EnvironmentId = 1,                
                LevelId = 3
            };

            var result = controller.Create(newLog);
            Assert.IsType<ActionResult<EntityBase>>(result);
            var actionResult = Assert.IsType<CreatedResult>(result.Result);
            var valueResult = Assert.IsType<EntityBase>(actionResult.Value);

            var actual = context.Logs.SingleOrDefault(x => x.Id == valueResult.Id);
            Assert.Equal(newLog.Title, actual.Title);
        }

        [Fact]
        public void Archive_ShouldWork()
        {
            var context = _contextFake.GetContext("Archive_ShouldWork")
                .AddFakeEnvironments()
                .AddFakeLevels()
                .AddFakeUsers()
                .AddFakeLogs()
                .AddFakeEvents();

            var repo = new LogRepository(context);

            var log = context.Logs.FirstOrDefault();                       
            var controller = new LogsController(repo, _mapper, _userManager);

            var result = controller.Archive(1);
            var actionResult = Assert.IsType<NoContentResult>(result);


            Assert.True(context.Logs.Where(log => log.Id == 1).FirstOrDefault().Archived);
            
        }      
        

        [Fact]
        public void Delete_ShouldWork()
        {
            var context = _contextFake
                .GetContext("Delete_ShouldWork")
                .AddFakeEnvironments()
                .AddFakeLevels()
                .AddFakeUsers()
                .AddFakeLogs()
                .AddFakeEvents();

            var repo = new LogRepository(context);

            var controller = new LogsController(repo, _mapper, _userManager);
            var deleteLog = context.Logs.FirstOrDefault();

            var result = controller.Delete(deleteLog.Id);
            var actionResult = Assert.IsType<NoContentResult>(result);

            var actual = context.Logs.SingleOrDefault(x => x.Id == deleteLog.Id);
            Assert.Null(actual);
        }

        [Fact]
        public void Delete_NotFoundIdLog()
        {
            var context = _contextFake.GetContext("Delete_NotFoundIdLog")
                .AddFakeEnvironments()
                .AddFakeLevels()
                .AddFakeUsers()
                .AddFakeLogs()
                .AddFakeEvents();

            var repo = new LogRepository(context);

            var controller = new LogsController(repo, _mapper, _userManager);

            var result = controller.Delete(int.MaxValue);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
