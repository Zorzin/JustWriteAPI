using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JustWriteAPI.Models.Parameters.Authentication;
using JustWriteAPI.Repositories.Interfaces;
using JustWriteAPI.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JustWriteAPI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _config;
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationService(IConfiguration config, IAuthenticationRepository authenticationRepository)
        {
            _config = config;
            _authenticationRepository = authenticationRepository;
        }


        public async Task<AuthorAuthenticationModel> AuthenticateUser(LoginModel login)
        {
            if (string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password)) return null;

            var userId = await this._authenticationRepository.GetUserId(login.Username);
            var dbModel = await this._authenticationRepository.GetAuthorAuthenticationModel(userId);

            if (BCrypt.CheckPassword(login.Password, dbModel.Password))
            {
                return dbModel;
            }

            return null;
        }

        public string BuildToken(AuthorAuthenticationModel authorAuthentication)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, authorAuthentication.Login),
                new Claim(JwtRegisteredClaimNames.Email, authorAuthentication.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
