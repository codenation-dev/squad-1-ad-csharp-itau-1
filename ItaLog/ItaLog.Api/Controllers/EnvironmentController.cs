using AutoMapper;
using ItaLog.Api.ViewModels;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ItaLog.Api.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EnvironmentController : ControllerBase
    {
        private readonly IEnvironmentRepository _repo;
        private readonly IMapper _mapper;
        public EnvironmentController(IEnvironmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Get filtered environment 
        /// </summary>
        /// <param name="pageFilter">Page filtering object</param>
        /// <response code="204">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>      
        /// <response code="404">Returned if the log is not found</response>      
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<PageViewModel<EnvironmentViewModel>> GetEnvironments(
        [FromQuery] PageFilter pageFilter)
        {
            var enviromnments = _repo.GetPage(pageFilter);

            return Ok(_mapper.Map<PageViewModel<EnvironmentViewModel>>(enviromnments));
        }

        /// <summary>
        /// Get environment by Id
        /// </summary>
        /// <param name="id">Environment identifier</param>
        /// <response code="204">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>      
        /// <response code="404">Returned if the log is not found</response>      
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var env = _mapper.Map<EnvironmentViewModel>(_repo.FindById(id));

            if (env is null)
                return NotFound();

            return Ok(env);
        }

        /// <summary>
        /// Creates an environment
        /// </summary>
        /// <param name="Env">Environment object</param>
        /// <response code="204">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>      
        /// <response code="404">Returned if the log is not found</response>      
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpPost]
        public ActionResult Create([FromBody] EnvironmentViewModel Env)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            _repo.Add(_mapper.Map<Domain.Models.Environment>(Env));

            return CreatedAtAction(nameof(GetById), new { id = Env.Id }, Env);
        }

        /// <summary>
        /// Update an environment
        /// </summary>
        /// <param name="id"> Environment Id</param>
        /// <param name="Env"> Environment object</param>
        /// <response code="204">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>      
        /// <response code="404">Returned if the log is not found</response>      
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] EnvironmentViewModel Env)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            if (Env.Id != id)
                return BadRequest();

            var EnvFind = _repo.FindById(id);
            EnvFind.Description = Env.Description;

            if (EnvFind is null)
                return NotFound();

            _repo.Update(EnvFind);

            return Ok();
        }

        /// <summary>
        /// Deletes an environment by Id
        /// </summary>
        /// <param name="id"> Environment Id</param>
        /// <response code="204">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>      
        /// <response code="404">Returned if the log is not found</response>      
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var envFind = _repo.FindById(id);

            if (envFind is null)
                return NotFound();

            _repo.Remove(id);

            return Ok();
        }
    }
}