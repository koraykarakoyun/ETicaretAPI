using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public bool Admin { get; set; }

        public ICollection<Basket> Basket { get; set; }
        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenLifeTime { get; set; }

    }
}
