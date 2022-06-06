﻿using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class User: IdentityUser
    {
        public UserInfo UserInfo { get; set; }
        public bool IsWorker { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }

    }
}
