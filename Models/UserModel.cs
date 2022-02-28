﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return "Name: " + UserName +
                ", Password: " + Password;
        }
    }
}
