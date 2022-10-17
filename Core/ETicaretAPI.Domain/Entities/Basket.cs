using ETicaretAPI.Domain.Common;
using ETicaretAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Basket : BaseEntity
    {
        //id(foreignKey)


        public string UserId { get; set; }



        public AppUser AppUser { get; set; }
        public Order Order { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }

    }
}
