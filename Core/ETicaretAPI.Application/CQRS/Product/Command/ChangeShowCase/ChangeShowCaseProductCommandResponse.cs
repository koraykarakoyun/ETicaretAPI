﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Command.ChangeShowCase
{
    public class ChangeShowCaseProductCommandResponse
    {

        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
