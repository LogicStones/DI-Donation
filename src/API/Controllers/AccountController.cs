using API.Helpers;
using API.Models;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppSettings _appSettings;
        private readonly ResponseEntity _response;
        private Dictionary<string, dynamic> dic;
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<AppSettings> appSettings,
            ResponseEntity response
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            _response = response;
            dic = new Dictionary<string, dynamic>();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromForm] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // Require the user to have a confirmed email before they can log on.
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    _response.error = true;
                    _response.message = ResponseMessageKeys.notFound;
                    return Ok(_response);
                }

                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    if (await _userManager.IsInRoleAsync(user, "Admin") || await _userManager.IsInRoleAsync(user, "Company"))
                    {
                        await _signInManager.SignOutAsync();

                        _response.error = false;
                        _response.message = ResponseMessageKeys.accessDenied;
                        return Ok(_response);
                    }

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                        }),
                        Issuer = "Survey-Management-System",
                        IssuedAt = DateTime.UtcNow,
                        NotBefore = DateTime.UtcNow,
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);

                    //await _userManager.UpdateAsync(user);

                    dic.Add("access_token", tokenHandler.WriteToken(token));
                    //dic.Add("compnyId", user.CompanyId);
                    dic.Add("userName", user.UserName);

                    //if (await _userManager.IsInRoleAsync(user, "User"))
                    //{
                    dic.Add("userID", user.Id);
                    //dic.Add("assignedFormId", user.AssignedFormId);
                    //dic.Add("companyId", user.CompanyId);
                    //}
                    _response.error = false;
                    _response.message = ResponseMessageKeys.success;
                    _response.data = dic;
                    return Ok(_response);
                }
                else
                {
                    _response.error = true;
                    _response.message = ResponseMessageKeys.invalidUserNameOrPassword;
                    return Ok(_response);
                }
            }
            else
            {
                _response.error = true;
                _response.message = ResponseMessageKeys.invalidParameters;
                return Ok(_response);
            }
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            _response.error = false;
            _response.message = ResponseMessageKeys.success;
            return Ok(_response);
        }
    }
}