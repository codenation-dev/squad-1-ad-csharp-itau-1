using ItaLog.Models;
using ItaLog.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItaLog.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogRepository _logRepository;
        public LogsController(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        [HttpGet]
        public IEnumerable<Log> GetLogs()
        {
            return _logRepository.GetLogs();
        }

        [HttpGet("{id}", Name = "GetLog")]
        public IActionResult GetById(int id)
        {
            var log = _logRepository.FindById(id);
            if (log is null)
                return NotFound();

            return new ObjectResult(log);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Log log)
        {
            if (log is null)
                return BadRequest();

            _logRepository.Add(log);

            return CreatedAtAction("GetLog", new { id = log.Id }, log);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Log log)
        {
            if (log is null || log.Id != id)
                return BadRequest();

            var logFind = _logRepository.FindById(id);

            if (logFind is null)
                return NotFound();

            logFind.Archive = log.Archive;

            _logRepository.Update(logFind);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var logFind = _logRepository.FindById(id);

            if (logFind is null)
                return NotFound();

            _logRepository.Remove(id);

            return new NoContentResult();
        }

    }
}
