using ETicaretAPI.Application.Abstraction.ApplicationServices;
using ETicaretAPI.Application.Const;
using ETicaretAPI.Application.CQRS.User.Command.Login;
using ETicaretAPI.Application.CustomAttributes;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Admin")]
    public class ApplicationServicesController : ControllerBase
    {
        readonly IApplicationServices _applicationServices;

        public ApplicationServicesController(IApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
        }

        [HttpGet("[action]")]
        [AuthorizeDefinition(ActionType =ActionType.Reading,Definiton = "Get Authorize Definiton Endpoints",Menu =AttributeConst.AuthorizeDefinition)]
        public async Task<IActionResult> GetAuthorizeDefinitonEndpoints()
        {

           List<Menu> menu=_applicationServices.GetAuthorizeDefinitonEndpoints(typeof(Program));
            return Ok(menu);
        }



    }
}
