﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string Role { get; set; }
    }
}
