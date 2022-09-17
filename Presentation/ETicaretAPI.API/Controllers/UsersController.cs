using ETicaretAPI.Application.CQRS.User.Command.CreateUser;
using ETicaretAPI.Application.CQRS.User.Command.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {

            CreateUserCommandResponse createUserCommandResponse = await _mediator.Send(createUserCommandRequest);
            return Ok(createUserCommandResponse);



        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginCommandRequest loginCommandRequest)
        {

            LoginCommandResponse loginCommandResponse = await _mediator.Send(loginCommandRequest);
            return Ok(loginCommandResponse);



        }




    }
}
