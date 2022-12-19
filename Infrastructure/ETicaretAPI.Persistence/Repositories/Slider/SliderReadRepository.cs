using ETicaretAPI.Application.Repositories.Slider;
using ETicaretAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.Slider
{
    public class SliderReadRepository : ReadRepository<Domain.Entities.Slider>, ISliderReadRepository
    {
        public SliderReadRepository(ETicaretDbContext context) : base(context)
        {
        }
    }
}
