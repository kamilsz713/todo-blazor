using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Core.Entity;

namespace Todo.Backend.Infrastructure.Auth
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
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
