using ETicaretAPI.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs
{
    public class Action
    {
        public string actionType { get; set; }

        public string Definiton { get; set; }

        public string HttpType { get; set; }

        public string Code { get; set; }

    }
}
