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
using System;
using System.Linq;
using Xunit;

namespace ItaLog.Test.ApiTests.Controllers
{
    public class LogsControllerTests
    {
        private readonly IMapper _mapper;
        public LogsControllerTests()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfig());
            });
            _mapper = configuration.CreateMapper();
        }

        [Fact]
        public void GetLogs_ShouldWork()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("GetLogs_ShouldWork");
            context = contextFake.AddFakeEnvironments(context);
            context = contextFake.AddFakeLevels(context);
            context = contextFake.AddFakeUsers(context);
            context = contextFake.AddFakeLogs(context);
            context = contextFake.AddFakeEvents(context);


            var repo = new LogRepository(context);
            UserManager<User> userManager = new UserManager<User>();

            var controller = new LogsController(repo, _mapper,  userManager);
            var pageFilter = new PageFilter();
            var logFilter = new LogFilter();
            var result = controller.GetLogs(pageFilter, logFilter, null);

            Assert.IsType<ActionResult<PageViewModel<LogEventViewModel>>>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<PageViewModel<LogEventViewModel>>(actionResult.Value);
        }

        [Fact]
        public void GetById_ShouldWork()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("GetById_ShouldWork");
            context = contextFake.AddFakeEnvironments(context);
            context = contextFake.AddFakeLevels(context);
            context = contextFake.AddFakeUsers(context);
            context = contextFake.AddFakeLogs(context);
            context = contextFake.AddFakeEvents(context);

            var repo = new LogRepository(context);

            UserManager<User> userManager = new UserManager<User>();
            

            var controller = new LogsController(repo, _mapper,  userManager);

            var result = controller.GetById(1);

            Assert.IsType<ActionResult<LogEventViewModel>>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<LogEventViewModel>(actionResult.Value);
        }

        [Fact]
        public void GetById_Notfound()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("GetById_Notfound");
            context = contextFake.AddFakeEnvironments(context);
            context = contextFake.AddFakeLevels(context);
            context = contextFake.AddFakeUsers(context);
            context = contextFake.AddFakeLogs(context);
            context = contextFake.AddFakeEvents(context);

            var repo = new LogRepository(context);
            UserManager<User> userManager = new UserManager<User>();

            var controller = new LogsController(repo, _mapper,  userManager);

            var result = controller.GetById(int.MaxValue);

            Assert.IsType<ActionResult<LogEventViewModel>>(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void Create_ShouldWork()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("Create_ShouldWork");
            context = contextFake.AddFakeEnvironments(context);
            context = contextFake.AddFakeLevels(context);
            context = contextFake.AddFakeUsers(context);
            context = contextFake.AddFakeLogs(context);
            context = contextFake.AddFakeEvents(context);

            var repo = new LogRepository(context);
            UserManager<User> userManager = new UserManager<User>();

            var controller = new LogsController(repo, _mapper,  userManager);
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
            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            var valueResult = Assert.IsType<EntityBase>(actionResult.Value);

            var actual = context.Logs.SingleOrDefault(x => x.Id == valueResult.Id);
            Assert.Equal(newLog.Title, actual.Title);
        }

        [Fact]
        public void Archive_ShouldWork()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("Archive_ShouldWork");
            context = contextFake.AddFakeEnvironments(context);
            context = contextFake.AddFakeLevels(context);
            context = contextFake.AddFakeUsers(context);
            context = contextFake.AddFakeLogs(context);
            context = contextFake.AddFakeEvents(context);

            var repo = new LogRepository(context);
            UserManager<User> userManager = new UserManager<User>();

            var controller = new LogsController(repo, _mapper,  userManager);

            var log = context.Logs.FirstOrDefault();            

            var result = controller.Archive(1);
            var actionResult = Assert.IsType<NoContentResult>(result);
            Assert.True(context.Logs.Where(log => log.Id == 1).FirstOrDefault().Archived);
            
        }      
        

        [Fact]
        public void Delete_ShouldWork()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("Delete_ShouldWork");
            context = contextFake.AddFakeEnvironments(context);
            context = contextFake.AddFakeLevels(context);
            context = contextFake.AddFakeUsers(context);
            context = contextFake.AddFakeLogs(context);
            context = contextFake.AddFakeEvents(context);

            var repo = new LogRepository(context);
            UserManager<User> userManager = new UserManager<User>();

            var controller = new LogsController(repo, _mapper,  userManager);
            var deleteLog = context.Logs.FirstOrDefault();

            var result = controller.Delete(deleteLog.Id);
            var actionResult = Assert.IsType<NoContentResult>(result);

            var actual = context.Logs.SingleOrDefault(x => x.Id == deleteLog.Id);
            Assert.Null(actual);
        }

        [Fact]
        public void Delete_NotFoundIdLog()
        {
            var contextFake = new ContextFake();
            var context = contextFake.GetContext("Delete_NotFoundIdLog");
            context = contextFake.AddFakeEnvironments(context);
            context = contextFake.AddFakeLevels(context);
            context = contextFake.AddFakeUsers(context);
            context = contextFake.AddFakeLogs(context);
            context = contextFake.AddFakeEvents(context);

            var repo = new LogRepository(context);
            UserManager<User> userManager = new UserManager<User>();

            var controller = new LogsController(repo, _mapper,  userManager);

            var result = controller.Delete(int.MaxValue);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
