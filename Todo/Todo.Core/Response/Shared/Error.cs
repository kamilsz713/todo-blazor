using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Enum;

namespace Todo.Core.Response.Shared
{
    public record Error(ErrorType Type, string Message);
}
