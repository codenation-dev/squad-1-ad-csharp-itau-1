using ItaLog.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ItaLog.Api.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController()
        {

        }

        [HttpPost]
        public async Task<ActionResult> Register(UserRegistrationViewModel userRegistration)
        {
            // TODO
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserLoginViewModel userLogin)
        {
            // TODO
            return NotFound();
        }
    }
}
