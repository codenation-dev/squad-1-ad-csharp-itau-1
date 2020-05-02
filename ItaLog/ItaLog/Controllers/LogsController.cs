using AutoMapper;
using ItaLog.Application.ViewModels;
using ItaLog.Domain.Exceptions;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
        public ActionResult<PageViewModel<LogItemPageViewModel>> GetLogs(
             [FromQuery] PageFilter pageFilter,
             [FromQuery] LogFilter logFilter,
             [FromQuery] string orderBy = "")

        {            
            var logs = _repo.GetPage(logFilter, pageFilter, orderBy);
            return Ok(_mapper.Map<PageViewModel<LogItemPageViewModel>>(logs));
        }

        [HttpGet("{id}")]
        public ActionResult<LogViewModel> GetById(int id)
        {
            var log = _mapper.Map<LogViewModel>(_repo.FindById(id));
            if (log is null)
                return NotFound();

            return Ok(_mapper.Map<LogViewModel>(log));
        }

        [HttpPost]
        public ActionResult Create([FromBody] LogEventViewModel logEvent)
        {
            int newId = 0;

            var log = _mapper.Map<Log>(logEvent);

            try
            {
                newId = _repo.Add(log);
            }
            catch (ForeignKeyNotFoundException ex)
            {
                ModelState.AddModelError(ex.NameFieldForeignKey, ex.Message);
                return BadRequest(new ValidationProblemDetails(ModelState));
            }
            
            return Created(nameof(GetById), new { id = newId });
        }

        [HttpPut("{id}/Archive")]
        public ActionResult Archive(int id)
        {
            var logFind = _repo.FindById(id);

            if (logFind is null)
                return NotFound();

            _repo.Archive(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var logFind = _repo.FindById(id);

            if (logFind is null)
                return NotFound();

            _repo.Remove(id);
            return NoContent();
        }

    }
}
