using ItaLog.Application.Interface;
using ItaLog.Application.ViewModels;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ItaLog.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogApplication _repository;
        public LogsController(ILogApplication repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<LogViewModel> GetLogs()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var log = _repository.FindById(id);
            if (log is null)
                return NotFound();

            return new ObjectResult(log);
        }

        [HttpPost]
        public IActionResult Create([FromBody] LogViewModel log)
        {
            if (log is null)
                return BadRequest();

            _repository.Add(log);

            return CreatedAtAction(nameof(GetById), new { id = log.Id }, log);
        }

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, [FromBody] Log log)
        //{
        //    if (log is null || log.Id != id)
        //        return BadRequest();

        //    var logFind = _logRepository.FindById(id);

        //    if (logFind is null)
        //        return NotFound();

        //    logFind.Archive = log.Archive;

        //    _logRepository.Update(logFind);

        //    return new NoContentResult();
        //}

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var logFind = _repository.FindById(id);

            if (logFind is null)
                return NotFound();

            _repository.Remove(id);

            return new NoContentResult();
        }

    }
}
