using ItaLog.Application.Interface;
using ItaLog.Application.ViewModels;
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
        private readonly IApiUserApplication _userApplication;
        public ApiUserController(IApiUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        [HttpGet]
        public IEnumerable<ApiUserViewModel> Users()
        {
            return _userApplication.GetAll();
        }

        [HttpGet]
        public IActionResult Id(int id)
        {
            var user = _userApplication.FindById(id);
            if (user is null)
                return NotFound();

            return new ObjectResult(user);
        }

        [HttpGet]
        public IActionResult Name(string name)
        {
            var user = _userApplication.FindByName(name);
            if (user is null)
                return NotFound();

            return new ObjectResult(user);
        }

        [HttpGet]
        public IActionResult Email(string email)
        {
            var user = _userApplication.FindByEmail(email);
            if (user is null)
                return NotFound();

            return new ObjectResult(user);
        }
    }
}