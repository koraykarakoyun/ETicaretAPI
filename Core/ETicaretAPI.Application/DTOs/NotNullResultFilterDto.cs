using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs
{
    public class NotNullResultFilterDto
    {
        public string? Brand { get; set; }

        public string? Model { get; set; }

        public string? Color { get; set; }

        public string? Category { get; set; }
    }
}
