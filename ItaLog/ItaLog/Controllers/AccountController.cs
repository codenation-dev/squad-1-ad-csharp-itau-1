using ItaLog.Api.Configurations;
using ItaLog.Application.ViewModels.Account;
using ItaLog.Domain.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly AppSettings _appSettings;
        private readonly IEmailSender _emailSender;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager,
            IOptions<AppSettings> appSettings, IEmailSender emailSender)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _emailSender = emailSender;
        }

        [HttpPost]
        [AllowAnonymous]
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

        [HttpPost]
        [AllowAnonymous]
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
