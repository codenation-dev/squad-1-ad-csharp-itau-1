using AutoMapper;
using ItaLog.Application.ViewModels;
using ItaLog.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace ItaLog.Api.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<UserViewModel> Users()
        {
            return _mapper.Map<List<UserViewModel>>(_repo.GetAll());
        }

        [HttpGet]
        public IActionResult Id(int id)
        {
            var user = _mapper.Map<UserViewModel>(_repo.FindById(id));
            if (user is null)
                return NotFound();

            return new ObjectResult(user);
        }

        [HttpGet]
        public IActionResult Name(string name)
        {
            var user = _mapper.Map<UserViewModel>(_repo.FindByName(name));
            if (user is null)
                return NotFound();

            return new ObjectResult(user);
        }

        [HttpGet]
        public IActionResult Email(string email)
        {
            var user = _mapper.Map<UserViewModel>(_repo.FindByEmail(email));
            if (user is null)
                return NotFound();

            return new ObjectResult(user);
        }
    }
}