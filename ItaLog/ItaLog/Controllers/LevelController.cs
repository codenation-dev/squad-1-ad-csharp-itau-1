using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ItaLog.Application.ViewModels;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public ActionResult<IEnumerable<LevelViewModel>> GetLevels()
        {
            return Ok(_mapper.Map<IEnumerable<LevelViewModel>>(_repo.GetAll()));
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var level = _mapper.Map<LevelViewModel>(_repo.FindById(id));

            if (level is null)
                return NotFound();

            return Ok(level);
        }

        [HttpPost]
        public ActionResult Create([FromBody] LevelViewModel level)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            _repo.Add(_mapper.Map<Level>(level));

            return CreatedAtAction(nameof(GetById), new { id = level.Id }, level);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] LevelViewModel level)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            if (level.Id != id)
                return BadRequest();

            var levelFind = _repo.FindById(id);

            if (levelFind is null)
                return NotFound();

            levelFind.Description = level.Description;

            _repo.Update(levelFind);

            return Ok();
        }

        [HttpDelete("{id}")]
        public 
            ActionResult Delete(int id)
        {
            var userFind = _repo.FindById(id);

            if (userFind is null)
                return NotFound();

            _repo.Remove(id);

            return Ok();
        }
    }
}