using ItaLog.Application.Interface;
using ItaLog.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ItaLog.Api.Controllers
{
    [Authorize]
    [Route("api/[Controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogApplication _app;
        public LogsController(ILogApplication repository)
        {
            _app = repository;
        }

        [HttpGet]
        public PageViewModel<LogItemPageViewModel> GetLogs(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageLength = 20)
        {
            return _app.GetPage(pageNumber, pageLength);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var log = _app.FindById(id);
            if (log is null)
                return NotFound();

            return new ObjectResult(log);
        }

        [HttpPost]
        public IActionResult Create([FromBody] LogEventViewModel log)
        {
            if (log is null)
                return BadRequest();

           _app.Add(log);

            return NoContent();
        }

        [HttpPost("{id}/Archive")]
        public IActionResult Archive(int id)
        {
            var logFind = _app.FindById(id);

            if (logFind is null)
                return NotFound();

            _app.Archive(id);         
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var logFind = _app.FindById(id);

            if (logFind is null)
                return NotFound();

            _app.Remove(id);
            return new NoContentResult();
        }

    }
}
