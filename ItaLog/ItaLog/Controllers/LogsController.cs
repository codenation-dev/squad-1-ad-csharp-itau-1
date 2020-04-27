using AutoMapper;
using ItaLog.Application.Interface;
using ItaLog.Application.ViewModels;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ItaLog.Api.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[Controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogRepository _repo;
        private readonly IMapper _mapper;

        public LogsController(ILogRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public PageViewModel<LogItemPageViewModel> GetLogs(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageLength = 20)
        {
            var pageLog = _repo.GetPage(pageNumber, pageLength);
            return _mapper.Map<PageViewModel<LogItemPageViewModel>>(pageLog);
        }

       

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var log = _mapper.Map<LogViewModel>(_repo.FindById(id));
            if (log is null)
                return NotFound();

            return new ObjectResult(log);
        }

        [HttpPost]
        public IActionResult Create([FromBody] LogEventViewModel log)
        {
            if (log is null)
                return BadRequest();

            var Log = _mapper.Map<Log>(log);

            Log.Events = new List<Event>()
            {
                new Event()
                {
                    Detail = log.Detail,
                    ErrorDate = log.ErrorDate
                }
            };

            _repo.Add(Log);

            return NoContent();
        }

        [HttpPost("{id}/Archive")]
        public IActionResult Archive(int id)
        {
            var logFind = _repo.FindById(id);

            if (logFind is null)
                return NotFound();

            _repo.Archive(id);         
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var logFind = _repo.FindById(id);

            if (logFind is null)
                return NotFound();

            _repo.Remove(id);
            return new NoContentResult();
        }

    }
}
