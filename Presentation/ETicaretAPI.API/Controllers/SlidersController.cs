using ETicaretAPI.Application.Const;
using ETicaretAPI.Application.CQRS.Category.Command.AddCategory;
using ETicaretAPI.Application.CQRS.Category.Command.DeleteCategory;
using ETicaretAPI.Application.CQRS.Category.Command.UpdateCategory;
using ETicaretAPI.Application.CQRS.Category.Query.GetAllCategories;
using ETicaretAPI.Application.CQRS.Slider.Command.AddSlidePhoto;
using ETicaretAPI.Application.CQRS.Slider.Command.DeletByIdShowCase;
using ETicaretAPI.Application.CQRS.Slider.Command.UpdateByIdSlidePhoto;
using ETicaretAPI.Application.CQRS.Slider.Query.GetAllSlidePhotos;
using ETicaretAPI.Application.CustomAttributes;
using ETicaretAPI.Application.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SlidersController : ControllerBase
    {

        IMediator _mediator;
        readonly IWebHostEnvironment _webHostEnvironment;
        public SlidersController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("[action]")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AttributeConst.Sliders, ActionType = ActionType.Writing, Definiton = "Add Slide Photo")]
        public async Task<IActionResult> AddSlidePhoto([FromForm] AddSlidePhotoCommandSliderRequest addSlidePhotoCommandSliderRequest)
        {
            AddSlidePhotoCommandSliderResponse addSlidePhotoCommandSliderResponse = await _mediator.Send(addSlidePhotoCommandSliderRequest);
            return Ok(addSlidePhotoCommandSliderResponse);

        }

        [HttpDelete("[action]/{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AttributeConst.Sliders, ActionType = ActionType.Deleting, Definiton = "Delete By Id Slide Photo")]
        public async Task<IActionResult> DeleteByIdSlidePhoto([FromRoute] DeleteByIdSlidePhotoCommandRequest deleteByIdSlidePhotoCommandRequest)
        {
            DeleteByIdSlidePhotoCommandResponse deleteByIdSlidePhotoCommandResponse = await _mediator.Send(deleteByIdSlidePhotoCommandRequest);
            return Ok(deleteByIdSlidePhotoCommandResponse);
        }


        [HttpGet("[action]")]
        [AuthorizeDefinition(Menu = AttributeConst.Sliders, ActionType = ActionType.Reading, Definiton = "Get All Slide Photo")]
        public async Task<IActionResult> GetAllSlidePhoto([FromRoute] GetAllSlidePhotosQuerySliderRequest getAllSlidePhotosQuerySliderRequest)
        {
            List<GetAllSlidePhotosQuerySliderResponse> getAllSlidePhotosQuerySliderResponse = await _mediator.Send(getAllSlidePhotosQuerySliderRequest);
            return Ok(getAllSlidePhotosQuerySliderResponse);

        }

        [HttpDelete("[action]/{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AttributeConst.Sliders, ActionType = ActionType.Deleting, Definiton = "Delete ShowCase Slide Photo")]
        public async Task<IActionResult> DeleteByIdShowCase([FromRoute] DeleteByIdShowCaseCommandSliderRequest deleteByIdShowCaseCommandSliderRequest)
        {
           DeleteByIdShowCaseCommandSliderResponse deleteByIdShowCaseCommandSliderResponse = await _mediator.Send(deleteByIdShowCaseCommandSliderRequest);
            return Ok(deleteByIdShowCaseCommandSliderResponse);

        }

    }
}
