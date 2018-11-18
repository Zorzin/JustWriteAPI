using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustWriteAPI.Models.Parameters.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace JustWriteAPI.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> GetToken(LoginModel loginModel);
    }
}
