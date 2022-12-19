using ETicaretAPI.Application.Repositories.Slider;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Slider.Command.DeletByIdShowCase
{
    public class DeleteByIdShowCaseCommandSliderHandler : IRequestHandler<DeleteByIdShowCaseCommandSliderRequest, DeleteByIdShowCaseCommandSliderResponse>
    {

        ISliderWriteRepository _sliderWriteRepository;
        ISliderReadRepository _sliderReadRepository;

        public DeleteByIdShowCaseCommandSliderHandler(ISliderWriteRepository sliderWriteRepository, ISliderReadRepository sliderReadRepository)
        {
            _sliderWriteRepository = sliderWriteRepository;
            _sliderReadRepository = sliderReadRepository;
        }

        public async Task<DeleteByIdShowCaseCommandSliderResponse> Handle(DeleteByIdShowCaseCommandSliderRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Slider slider = await _sliderReadRepository.GetByIdAsync(request.Id);
            slider.ShowCase = false;
            await _sliderWriteRepository.SaveAsync();
            return new()
            {
                issucess = true,
                Message = "Resim Vitrinden Kaldırıldı"
            };
        }
    }
}
