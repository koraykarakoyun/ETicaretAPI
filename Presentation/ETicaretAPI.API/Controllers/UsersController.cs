using ETicaretAPI.Application.Const;
using ETicaretAPI.Application.CQRS.User.Command.AssignUserRoles;
using ETicaretAPI.Application.CQRS.User.Command.CreateUser;
using ETicaretAPI.Application.CQRS.User.Command.FacebookLogin;
using ETicaretAPI.Application.CQRS.User.Command.GoogleLogin;
using ETicaretAPI.Application.CQRS.User.Command.Login;
using ETicaretAPI.Application.CQRS.User.Query.GetAllUsers;
using ETicaretAPI.Application.CQRS.User.Query.GetUserRoles;
using ETicaretAPI.Application.CustomAttributes;
using ETicaretAPI.Application.Enums;
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



        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AttributeConst.Users, ActionType = ActionType.Reading, Definiton = "Get All Users")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersQueryRequest getAllUsersQueryRequest)
        {

            List<GetAllUsersQueryResponse> getAllUsersQueryResponse = await _mediator.Send(getAllUsersQueryRequest);
            return Ok(getAllUsersQueryResponse);

        }


        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AttributeConst.Users, ActionType = ActionType.Writing, Definiton = "Assign User Roles")]
        public async Task<IActionResult> AssignUserRoles(AssignUserRolesRequest assignUserRolesRequest)
        {
            AssignUserRolesResponse assignUserRolesResponse = await _mediator.Send(assignUserRolesRequest);
            return Ok(assignUserRolesResponse);

        }

        [HttpGet("GetByIdUserRoles/{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AttributeConst.Users, ActionType = ActionType.Reading, Definiton = "Get User Roles")]
        public async Task<IActionResult> GetByIdUserRoles([FromRoute] GetByIdUserRolesRequest getByIdUserRolesRequest)
        {
            GetByIdUserRolesResponse getByIdUserRolesResponse = await _mediator.Send(getByIdUserRolesRequest);
            return Ok(getByIdUserRolesResponse);

        }


       


    }
}
