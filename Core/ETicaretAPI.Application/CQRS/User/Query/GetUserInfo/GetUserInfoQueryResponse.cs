using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.User.Query.GetUserPhoneNumber
{
    public class GetUserInfoQueryResponse
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }
    }
}
