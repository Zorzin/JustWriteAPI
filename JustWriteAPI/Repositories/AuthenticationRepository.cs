using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustWriteAPI.Models.Database;
using JustWriteAPI.Models.Parameters.Authentication;
using JustWriteAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JustWriteAPI.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly Context _context;
        public AuthenticationRepository(Context context)
        {
            _context = context;
        }

        public async Task<LoginModel> GetLoginAndPassword(int userId)
        {
            return await this._context.Authors.Where(x => x.Id == userId)
                .Select(x => new LoginModel() {Password = x.Password, Username = x.Login}).FirstOrDefaultAsync();
        }

        public async Task<int> GetUserId(string username)
        {
            return await this._context.Authors.Where(x => x.Login == username).Select(x => x.Id).FirstOrDefaultAsync();
        }

        public async Task<AuthorAuthenticationModel> GetAuthorAuthenticationModel(int userId)
        {
            return await this._context.Authors.Where(x => x.Id == userId)
                .Select(x => new AuthorAuthenticationModel() { Password = x.Password, Email = x.Email, Login = x.Login}).FirstOrDefaultAsync();
        }
    }
}
