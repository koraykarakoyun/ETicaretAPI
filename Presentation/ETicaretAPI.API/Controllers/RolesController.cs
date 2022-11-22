using ETicaretAPI.Application.Const;
using ETicaretAPI.Application.CQRS.Role.Command.CreateRole;
using ETicaretAPI.Application.CQRS.Role.Command.DeleteRole;
using ETicaretAPI.Application.CQRS.Role.Command.UpdateRole;
using ETicaretAPI.Application.CQRS.Role.Query.GetAllRoles;
using ETicaretAPI.Application.CQRS.Role.Query.GetRoleById;
using ETicaretAPI.Application.CQRS.User.Command.CreateUser;
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
    public class RolesController : ControllerBase
    {

        readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        [AuthorizeDefinition(Menu = AttributeConst.Roles, ActionType = ActionType.Reading, Definiton = "Get All Roles")]
        public async Task<IActionResult> GetAllRoles([FromQuery] GetAllRolesQueryRequest getAllRolesQueryRequest)
        {
            GetAllRolesQueryResponse getAllRolesQueryResponse = await _mediator.Send(getAllRolesQueryRequest);
            return Ok(getAllRolesQueryResponse);

        }

        [HttpGet("[action]/{Id}")]
        [AuthorizeDefinition(Menu = AttributeConst.Roles, ActionType = ActionType.Reading, Definiton = "Get Role By Id")]
        public async Task<IActionResult> GetRoleById([FromRoute] GetRoleByIdQueryRequest getRoleByIdQueryRequest)
        {
            GetRoleByIdQueryResponse getRoleByIdQueryResponse = await _mediator.Send(getRoleByIdQueryRequest);
            return Ok(getRoleByIdQueryResponse);

        }

        [HttpPost("[action]")]
        [AuthorizeDefinition(Menu = AttributeConst.Roles, ActionType = ActionType.Writing, Definiton = "Create Role")]
        public async Task<IActionResult> CreateRole(CreateRoleCommandRequest createRoleCommandRequest)
        {
            CreateRoleCommandResponse createRoleCommandResponse = await _mediator.Send(createRoleCommandRequest);
            return Ok(createRoleCommandResponse);

        }



        [HttpDelete("DeleteRole/{Id}")]
        [AuthorizeDefinition(Menu = AttributeConst.Roles, ActionType = ActionType.Deleting, Definiton = "Delete Role")]
        public async Task<IActionResult> DeleteRole([FromRoute] DeleteRoleCommandRequest deleteRoleCommandRequest)
        {
            DeleteRoleCommandResponse deleteRoleCommandResponse = await _mediator.Send(deleteRoleCommandRequest);
            return Ok(deleteRoleCommandResponse);

        }

        [HttpPut("[action]")]
        [AuthorizeDefinition(Menu = AttributeConst.Roles, ActionType = ActionType.Updateing, Definiton = "Update Role")]
        public async Task<IActionResult> UpdateRole(UpdateRoleCommandRequest updateRoleCommandRequest)
        {
            UpdateRoleCommandResponse updateRoleCommandResponse = await _mediator.Send(updateRoleCommandRequest);
            return Ok(updateRoleCommandResponse);

        }






    }
}
