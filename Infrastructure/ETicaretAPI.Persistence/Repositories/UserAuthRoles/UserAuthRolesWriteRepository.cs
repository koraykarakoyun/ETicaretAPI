using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.UserAuthRoles;
using ETicaretAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.UserAuthRoles
{
    public class UserAuthRolesWriteRepository : WriteRepsitory<Domain.Entities.UserAuthRole>, IUserAuthRolesWriteRepository
    {
        public UserAuthRolesWriteRepository(ETicaretDbContext context) : base(context)
        {
        }
    }
}
