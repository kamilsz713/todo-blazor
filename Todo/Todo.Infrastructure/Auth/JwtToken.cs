using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Backend.Infrastructure.Auth
{
    public record JwtToken(string Token, long ExpiresAt);
}
