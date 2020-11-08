using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Core.Entity;

namespace Todo.Backend.Infrastructure.Auth
{
    public class PasswordHasher : IPasswordHasher<Account>
    {
        public string HashPassword(Account user, string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public PasswordVerificationResult VerifyHashedPassword(Account user, string hashedPassword, string providedPassword)
        {
            var res = BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);

            if(res)
            {
                return PasswordVerificationResult.Success;
            }
            else
            {
                return PasswordVerificationResult.Failed;
            }
        }
    }
}
