﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs
{
    public class LoginDto
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public DTOs.Token Token { get; set; }
        public string UserAuthRoleName { get; set; }
    }
}
