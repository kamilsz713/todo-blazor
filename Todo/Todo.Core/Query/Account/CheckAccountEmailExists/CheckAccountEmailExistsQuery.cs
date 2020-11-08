using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Core.Query.Account.CheckAccountEmailExists
{
    public class CheckAccountEmailExistsQuery : IRequest<bool>
    {
        public string Email { get; set; }
    }
}
