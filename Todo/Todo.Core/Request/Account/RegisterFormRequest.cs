using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Core.Request.Account
{
    public class RegisterFormRequest
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string RepeatPassword { get; set; }

        public string Email { get; set; }
    }
}
