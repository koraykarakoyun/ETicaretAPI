using ETicaretAPI.Application.CQRS.User.Command.FacebookLogin;
using ETicaretAPI.Application.CQRS.User.Command.GoogleLogin;
using ETicaretAPI.Application.CQRS.User.Command.Login;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginCommandRequest loginCommandRequest)
        {
            LoginCommandResponse loginCommandResponse = await _mediator.Send(loginCommandRequest);
            return Ok(loginCommandResponse);
        }

        [HttpPost("google")]
        public async Task<IActionResult> Google(GoogleLoginCommandRequest googleLoginCommandRequest)
        {
            GoogleLoginCommandResponse googleLoginCommandResponse = await _mediator.Send(googleLoginCommandRequest);
            return Ok(googleLoginCommandResponse);
        }


        [HttpPost("facebook")]
        public async Task<IActionResult> Facebook(FacebookLoginCommandRequest facebookLoginCommandRequest)
        {
            FacebookLoginCommandResponse facebookLoginCommandResponse = await _mediator.Send(facebookLoginCommandRequest);
            return Ok(facebookLoginCommandResponse);
        }

    }
}
