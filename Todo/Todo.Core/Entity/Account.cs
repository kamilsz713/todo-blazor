using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Core.Entity
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
