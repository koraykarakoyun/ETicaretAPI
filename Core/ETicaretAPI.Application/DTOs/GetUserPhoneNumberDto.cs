using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs
{
    public class GetUserInfoDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }
    }
}
