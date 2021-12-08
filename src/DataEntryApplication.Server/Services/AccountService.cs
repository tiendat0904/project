
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using DataEntryApplication.Server.Data;
using DataEntryApplication.Server.Data.Entities;
using DataEntryApplication.Server.Services.Interfaces;
using DataEntryApplication.Shared;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;

namespace DataEntryApplication.Server.Services
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: loginModel.Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            var user = await DbContext.Accounts
                .Where(account => account.Username == loginModel.Email && hashed == loginModel.Password)
                .FirstOrDefaultAsync();
            if (user == null)
            {
                return new LoginResult()
                {
                    Error = "Username or password is invalid",
                    Role = 0,
                    Successful = false,
                    Token = ""
                };
            }
            else
            {
                return new LoginResult()
                {
                    Error = "",
                    Role = user.Role,
                    Successful = true,
                    Token = ""
                };
            }
        }
    }
}
