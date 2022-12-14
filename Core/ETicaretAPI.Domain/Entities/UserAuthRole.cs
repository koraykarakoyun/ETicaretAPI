using ETicaretAPI.Domain.Common;
using ETicaretAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class UserAuthRole:BaseEntity
    {
        public string RoleName { get; set; }

        public ICollection<AppUser> AppUsers { get; set; }

    }
}
