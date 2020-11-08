using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Core.Query.Account.CheckAccountLoginExists
{
    public class CheckAccountLoginExistsQuery : IRequest<bool>
    {
        public string Login { get; set; }
    }
}
