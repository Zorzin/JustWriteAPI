using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustWriteAPI.Models.Database;
using JustWriteAPI.Models.Parameters.Authentication;

namespace JustWriteAPI.Repositories.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<LoginModel> GetLoginAndPassword(int userId);
        Task<int> GetUserId(string username);
        Task<AuthorAuthenticationModel> GetAuthorAuthenticationModel(int userId);
    }
}
