﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Core.Entity
{
    public class AccountRole
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int RoleId { get; set; }
    }
}
