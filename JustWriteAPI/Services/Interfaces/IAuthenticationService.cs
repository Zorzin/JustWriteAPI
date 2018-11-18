using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustWriteAPI.Models.Parameters.Authentication;

namespace JustWriteAPI.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthorAuthenticationModel> AuthenticateUser(LoginModel login);
        string BuildToken(AuthorAuthenticationModel user);
    }
}
