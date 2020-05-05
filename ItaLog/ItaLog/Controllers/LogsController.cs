using AutoMapper;
using ItaLog.Application.ViewModels;
using ItaLog.Domain.Exceptions;
using ItaLog.Domain.Interfaces.Models;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        /// <summary>
        /// Returns a page of logs
        /// </summary>
        /// <param name="orderBy">Options: 'eventscount' or 'level'</param>
        /// <response code="200">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>      
        /// <response code="404">Returned if the log is not found</response>
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public ActionResult<PageViewModel<LogItemPageViewModel>> GetLogs(
             [FromQuery] PageFilter pageFilter,
             [FromQuery] LogFilter logFilter,
             [FromQuery] string orderBy = "")

        {
            var logs = _repo.GetPage(logFilter, pageFilter, orderBy);
            return Ok(_mapper.Map<PageViewModel<LogItemPageViewModel>>(logs));
        }

        /// <summary>
        /// Returns the details for an log
        /// </summary>
        /// <param name="id">Log identifier</param>
        /// <response code="200">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>      
        /// <response code="404">Returned if the log is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public ActionResult<LogViewModel> GetById(int id)
        {
            var log = _mapper.Map<LogViewModel>(_repo.FindById(id));
            if (log is null)
                return NoContent();

            return Ok(_mapper.Map<LogViewModel>(log));
        }

        /// <summary>
        /// Creates a log or a log event if it already exists
        /// </summary>
        /// <param name="logEvent">Objet of log</param>
        /// <response code="201">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>      
        /// <response code="404">Returned if the log is not found</response>
        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created, type: typeof(IEntity))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public ActionResult Create([FromBody] LogEventViewModel logEvent)
        {
            int newId = 0;

            var log = _mapper.Map<Log>(logEvent);

            if (log is null)
                return NoContent();

            try
            {
                newId = _repo.Add(log);
            }
            catch (ForeignKeyNotFoundException ex)
            {
                ModelState.AddModelError(ex.NameFieldForeignKey, ex.Message);
                return BadRequest(new ValidationProblemDetails(ModelState));
            }

            return Created(nameof(GetById), new { Id = newId });
        }

        /// <summary>
        /// Archive a log
        /// </summary>
        /// <param name="id">Log identifier</param>
        /// <response code="204">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>      
        /// <response code="404">Returned if the log is not found</response>      
        [HttpPut("{id}/Archive")]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public ActionResult Archive(int id)
        {
            var logFind = _repo.FindById(id);

            if (logFind is null)
                return NotFound();

            _repo.Archive(id);
            return NoContent();
        }

        /// <summary>
        /// Delete a log
        /// </summary>
        /// <param name="id">Log identifier</param>
        /// <response code="204">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>      
        /// <response code="404">Returned if the log is not found</response>      
        [HttpDelete("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
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
