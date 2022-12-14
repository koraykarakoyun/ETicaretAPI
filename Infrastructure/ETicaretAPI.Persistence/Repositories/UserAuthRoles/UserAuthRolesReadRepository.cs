using ETicaretAPI.Application.Repositories.UserAuthRoles;
using ETicaretAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.UserAuthRoles
{
    public class UserAuthRolesReadRepository : ReadRepository<Domain.Entities.UserAuthRole>, IUserAuthRolesReadRepository
    {
        public UserAuthRolesReadRepository(ETicaretDbContext context) : base(context)
        {
        }
    }
}
