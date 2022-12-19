using ETicaretAPI.Application.Repositories.Slider;
using ETicaretAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.Slider
{
    public class SliderWriteRepository : WriteRepsitory<Domain.Entities.Slider>, ISliderWriteRepository
    {
        public SliderWriteRepository(ETicaretDbContext context) : base(context)
        {
        }
    }
}
