using AutoMapper;
using ItaLog.Api.Configurations;
using ItaLog.Api.ViewModels;
using ItaLog.Api.ViewModels.Users;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItaLog.Api.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[Controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly TokenSettings _appSettings;
        private readonly IEmailSender _emailSender;

        public UsersController(IUserRepository userRepository, IMapper mapper, SignInManager<User> signInManager, UserManager<User> userManager,
            IOptions<TokenSettings> appSettings, IEmailSender emailSender)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _emailSender = emailSender;
        }


        /// <summary>
        /// Returns a page of users
        /// </summary>
        /// <param name="pageFilter">Page filtering data</param>
        /// <response code="204">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>      
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        public ActionResult<PageViewModel<UserViewModel>> Users(
        [FromQuery] PageFilter pageFilter)
        {
            var users = _userRepository.GetPage(pageFilter);

            return Ok(_mapper.Map<PageViewModel<UserViewModel>>(users));
        }

        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="id">User Identifier</param>
        /// <response code="204">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>      
        /// <response code="404">Returned if the user is not found</response>      
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public IActionResult Id(int id)
        {
            var user = _mapper.Map<UserViewModel>(_userRepository.FindById(id));
            if (user is null)
                return NotFound();

            return new ObjectResult(user);
        }

        /// <summary>
        /// Get user by e-mail
        /// </summary>
        /// <param name="email">User email</param>
        /// <response code="204">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>      
        /// <response code="404">Returned if the e-mail for user is not found</response>      
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public IActionResult Email(string email)
        {
            var user = _mapper.Map<UserViewModel>(_userRepository.FindByEmail(email));
            if (user is null)
                return NotFound();

            return new ObjectResult(user);
        }

        /// <summary>
        /// User register
        /// </summary>
        /// <param name="userRegistration">User object</param>
        /// <response code="204">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>              
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Register(UserRegistrationViewModel userRegistration)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var user = new User
            {
                UserToken = Guid.NewGuid(),
                Name = userRegistration.Name,
                UserName = userRegistration.Email,
                Email = userRegistration.Email,
                EmailConfirmed = true,
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, userRegistration.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _signInManager.SignInAsync(user, false);

            return Ok(await GenerateJwt(userRegistration.Email));
        }

        /// <summary>
        /// User Login (returns a token)
        /// </summary>
        /// <param name="userLogin">User data</param>
        /// <response code="204">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>         
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginViewModel userLogin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);

            if (result.Succeeded)
            {
                await _emailSender.SendEmailAsync(userLogin.Email, "New Login", $"<h2>Hey, new login to your account noticed!</h2><br><p>New login to your account at {DateTime.Now}</p>");
                return Ok(await GenerateJwt(userLogin.Email));
            }

            return BadRequest("Username or password is invalid");
        }

        /// <summary>
        /// Forgot password
        /// </summary>
        /// <param name="model">User data</param>
        /// <response code="204">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>      
        /// <response code="404">Returned if the e-mail for user is not found</response>      
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    return NotFound("Please check if you wrote something wrong and try again!");
                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                await _emailSender.SendEmailAsync(model.Email, "Reset Password", $"<strong>Please reset your password using the code below:</strong><br><br><strong>CODE:</strong> {token}");
                return Ok("Please check your email to reset your password.");
            }

            return BadRequest();
        }

        /// <summary>
        /// Password reset
        /// </summary>
        /// <param name="model">User data</param>
        /// <response code="204">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>      
        /// <response code="404">Returned if the e-mail for user is not found</response>      
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return NotFound();
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return Ok("Your password has been reset.");
            }

            return BadRequest();
        }

        /// <summary>
        /// Edit a user
        /// </summary>
        /// <param name="model">user object</param>
        /// <response code="204">Returned if the request is successful</response>
        /// <response code="400">Server cannot or will not process the request due to something that was perceived as a client error</response>      
        /// <response code="401">Returned if the authentication credentials are incorrect or missing.</response>
        /// <response code="404">Returned if the e-mail for user is not found</response>
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpPut]
        public async Task<IActionResult> Update(string email, string password, [FromBody] UserUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var result = await _signInManager.PasswordSignInAsync(email, password, false, true);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    user.Name = model.Name;
                    user.UserName = model.NewEmail;
                    user.Email = model.NewEmail;
                    user.NormalizedUserName = model.NewEmail.ToUpper();
                    user.LastUpdateDate = DateTime.Now;
                    _userRepository.Update(user);

                    return Ok("Your data has been updated.");
                }
                
                return NotFound("Please check if you wrote something wrong and try again!");
            }

            return BadRequest("Username or password is invalid");
        }
        private async Task<string> GenerateJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience,
                Expires = DateTime.UtcNow.AddHours(_appSettings.Expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
