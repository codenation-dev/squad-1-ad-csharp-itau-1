using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ItaLog.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<ApiUser> GetUsers()
        {
            return _userRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userRepository.FindById(id);
            if (user is null)
                return NotFound();

            return new ObjectResult(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ApiUser user)
        {
            if (user is null)
                return BadRequest();

            _userRepository.Add(user);

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ApiUser user)
        {
            if (user is null || user.Id != id)
                return BadRequest();

            var userFind = _userRepository.FindById(id);

            if (userFind is null)
                return NotFound();

            userFind.Name = user.Name;
            userFind.Password = user.Password;
            userFind.Email = user.Email;

            _userRepository.Update(userFind);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var userFind = _userRepository.FindById(id);

            if (userFind is null)
                return NotFound();

            _userRepository.Remove(id);

            return new NoContentResult();
        }
    }
}