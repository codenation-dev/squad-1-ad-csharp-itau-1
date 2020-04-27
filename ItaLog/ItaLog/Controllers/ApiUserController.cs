using AutoMapper;
using ItaLog.Application.Interface;
using ItaLog.Application.ViewModels;
using ItaLog.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace ItaLog.Api.Controllers
{
    [Authorize]
    [Route("api/Users/[action]")]
    [ApiController]
    public class ApiUserController : ControllerBase
    {
        private readonly IApiUserRepository _repo;
        private readonly IMapper _mapper;
        public ApiUserController(IApiUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ApiUserViewModel> Users()
        {
            return _mapper.Map<List<ApiUserViewModel>>(_repo.GetAll());
        }

        [HttpGet]
        public IActionResult Id(int id)
        {
            var user = _mapper.Map<ApiUserViewModel>(_repo.FindById(id));
            if (user is null)
                return NotFound();

            return new ObjectResult(user);
        }

        [HttpGet]
        public IActionResult Name(string name)
        {
            var user = _mapper.Map<ApiUserViewModel>(_repo.FindByName(name));
            if (user is null)
                return NotFound();

            return new ObjectResult(user);
        }

        [HttpGet]
        public IActionResult Email(string email)
        {
            var user = _mapper.Map<ApiUserViewModel>(_repo.FindByEmail(email));
            if (user is null)
                return NotFound();

            return new ObjectResult(user);
        }
    }
}