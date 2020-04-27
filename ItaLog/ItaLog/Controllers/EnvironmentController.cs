using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ItaLog.Application.Interface;
using ItaLog.Application.ViewModels;
using ItaLog.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItaLog.Api.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet]
        public ActionResult<IEnumerable<EnvironmentViewModel>> GetEnvironments()
        {
            return Ok(_mapper.Map<IEnumerable<EnvironmentViewModel>>(_repo.GetAll()));
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var env = _mapper.Map<EnvironmentViewModel>(_repo.FindById(id));

            if (env is null)
                return NotFound();

            return Ok(env);
        }

        [HttpPost]
        public ActionResult Create([FromBody] EnvironmentViewModel Env)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            _repo.Add(_mapper.Map<Domain.Models.Environment>(Env));

            return CreatedAtAction(nameof(GetById), new { id = Env.Id }, Env);
        }

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