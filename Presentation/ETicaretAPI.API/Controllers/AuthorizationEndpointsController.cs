using ETicaretAPI.Application.Const;
using ETicaretAPI.Application.CQRS.AuthorizationEndpoint.Command;
using ETicaretAPI.Application.CQRS.AuthorizationEndpoint.Command.AssingRoleEndpoint;
using ETicaretAPI.Application.CQRS.AuthorizationEndpoint.Command.GetRolesToEndpoint;
using ETicaretAPI.Application.CQRS.User.Command.Login;
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
    [Authorize(AuthenticationSchemes = "Admin")]
    public class AuthorizationEndpointsController : ControllerBase
    {

        IMediator _mediator;

        public AuthorizationEndpointsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetRolesToEndpoint")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definiton = "Get Roles To Endpoint", Menu = AttributeConst.AuthorizationEndpoints)]
        public async Task<IActionResult> GetRolesToEndpoint(GetRolesToEndpointCommandRequest getRolesToEndpointCommandRequest)
        {
            GetRolesToEndpointCommandResponse getRolesToEndpointCommandResponse = await _mediator.Send(getRolesToEndpointCommandRequest);
            return Ok(getRolesToEndpointCommandResponse);
        }


        [HttpPost("AssingRoleEndpoint")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definiton = "Assing Role Endpoint", Menu = AttributeConst.AuthorizationEndpoints)]
        public async Task<IActionResult> AssingRoleEndpoint(AssignRoleEndpointCommandRequest assignRoleEndpointCommandRequest)
        {
            assignRoleEndpointCommandRequest.Type = typeof(Program);
            AssignRoleEndpointCommandResponse assignRoleEndpointCommandResponse = await _mediator.Send(assignRoleEndpointCommandRequest);
            return Ok(assignRoleEndpointCommandResponse);
        }
    }
}
