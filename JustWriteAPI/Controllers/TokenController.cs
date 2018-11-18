using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JustWriteAPI.Models.Parameters.Authentication;
using JustWriteAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JustWriteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public TokenController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();
            var user = await Authenticate(login);

            if (user != null)
            {
                var tokenString = this._authenticationService.BuildToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private async Task<AuthorAuthenticationModel> Authenticate(LoginModel login)
        {
            return await this._authenticationService.AuthenticateUser(login);
            
        }
    }
}