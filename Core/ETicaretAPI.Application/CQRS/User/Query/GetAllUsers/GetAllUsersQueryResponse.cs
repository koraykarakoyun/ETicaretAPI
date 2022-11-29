using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.User.Query.GetAllUsers
{
    public class GetAllUsersQueryResponse
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool TwoFactoryEnable { get; set; }
    }
}
