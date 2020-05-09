using AutoMapper;
using ItaLog.Api.ViewModels;
using ItaLog.Api.ViewModels.Level;
using ItaLog.Domain.Interfaces.Models;
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
    public class LevelController : ControllerBase
    {
        private readonly ILevelRepository _repo;
        private readonly IMapper _mapper;
        public LevelController(ILevelRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns a page of levels
        /// </summary>
        /// <response code="200">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>          
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public ActionResult<PageViewModel<LevelViewModel>> GetLevels(
           [FromQuery] PageFilter pageFilter)
        {
            var levels = _repo.GetPage(pageFilter);

            return Ok(_mapper.Map<PageViewModel<LevelViewModel>>(levels));
        }

        /// <summary>
        /// Get level by id
        /// </summary>
        /// <param name="id">level identifier</param>
        /// <response code="200">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>      
        /// <response code="404">Returned if the level is not found</response>      
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<LevelViewModel> GetById(int id)
        {
            var level = _mapper.Map<LevelViewModel>(_repo.FindById(id));

            if (level is null)
                return NotFound();

            return Ok(level);
        }

        /// <summary>
        /// Creates a level
        /// </summary>
        /// <param name="level">level object</param>
        /// <response code="201">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>           
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult<EntityBase> Create([FromBody] LevelCreateViewModel level)
        {
            var newId = _repo.Add(_mapper.Map<Level>(level));
            return Created(nameof(GetById), new EntityBase { Id = newId });
        }

        /// <summary>
        /// Edits a level
        /// </summary>
        /// <param name="level">level object</param>
        /// <response code="204">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>      
        /// <response code="404">Returned if the level is not found</response>      
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] LevelViewModel level)
        {
            if (level.Id != id)
                return BadRequest();

            if (!_repo.ExistsEntity(id))
                return NotFound();

            _repo.Update(_mapper.Map<Level>(level));

            return NoContent();
        }

        /// <summary>
        /// Deletes a level by id
        /// </summary>
        /// <param name="id">Level id</param>
        /// <response code="204">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>      
        /// <response code="404">Returned if the level is not found</response>      
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var userFind = _repo.FindById(id);

            if (userFind is null)
                return NotFound();

            _repo.Remove(id);

            return NoContent();
        }
    }
}