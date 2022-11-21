using ETicaretAPI.Application.Abstraction.ApplicationServices;
using ETicaretAPI.Application.CQRS.User.Command.Login;
using ETicaretAPI.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationServicesController : ControllerBase
    {
        readonly IApplicationServices _applicationServices;

        public ApplicationServicesController(IApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAuthorizeDefinitonEndpoints()
        {

           List<Menu> menu=_applicationServices.GetAuthorizeDefinitonEndpoints(typeof(Program));
            return Ok(menu);
        }



    }
}
