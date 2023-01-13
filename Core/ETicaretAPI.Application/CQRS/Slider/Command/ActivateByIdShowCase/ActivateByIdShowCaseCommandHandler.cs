using ETicaretAPI.Application.Repositories.Slider;
using ETicaretAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Slider.Command.ActivateByIdShowCase
{
    public class ActivateByIdShowCaseCommandHandler : IRequestHandler<ActivateByIdShowCaseCommandRequest, ActivateByIdShowCaseCommandResponse>
    {
        ISliderWriteRepository _sliderWriteRepository;
        ISliderReadRepository _sliderReadRepository;

        public ActivateByIdShowCaseCommandHandler(ISliderWriteRepository sliderWriteRepository, ISliderReadRepository sliderReadRepository)
        {
            _sliderWriteRepository = sliderWriteRepository;
            _sliderReadRepository = sliderReadRepository;
        }

        public async Task<ActivateByIdShowCaseCommandResponse> Handle(ActivateByIdShowCaseCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Slider slider = await _sliderReadRepository.GetByIdAsync(request.Id);
            slider.ShowCase = true;
            await _sliderWriteRepository.SaveAsync();

            return new ActivateByIdShowCaseCommandResponse()
            {
                IsSuccess=true,
                Message = "Resim Vitrine Eklendi"
            };

        }
    }
}
