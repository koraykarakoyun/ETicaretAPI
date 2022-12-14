using ETicaretAPI.Application.Const;
using ETicaretAPI.Application.CQRS.AuthUserRole.Command.DeleteAuthUserRole;
using ETicaretAPI.Application.CQRS.AuthUserRole.Command.UpdateAuthUserRole;
using ETicaretAPI.Application.CQRS.UserAuthRole.Command.AddUserAuthRole;
using ETicaretAPI.Application.CQRS.UserAuthRole.Query.GetAllUserAuthRole;
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
    public class UserAuthRolesController : ControllerBase
    {

        IMediator _mediator;

        public UserAuthRolesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetUserAuthRole")]
        [AuthorizeDefinition(Menu = AttributeConst.UserAuthRoles, ActionType = ActionType.Reading, Definiton = "Get All User Auth Role")]
        public async Task<IActionResult> AddAuthUserRole([FromRoute] GetAllUserAuthRoleRequest getAllUserAuthRoleRequest)
        {
            List<GetAllUserAuthRoleResponse> getAllUserAuthRoleResponse = await _mediator.Send(getAllUserAuthRoleRequest);
            return Ok(getAllUserAuthRoleResponse);
        }

        [HttpPost("AddUserAuthRole")]
        [AuthorizeDefinition(Menu = AttributeConst.UserAuthRoles, ActionType = ActionType.Writing, Definiton = "Add User Auth Role")]
        public async Task<IActionResult> AddUserAuthRole(AddUserAuthRoleRequest addUserAuthRoleRequest)
        {
            AddUserAuthRoleResponse addUserAuthRoleResponse = await _mediator.Send(addUserAuthRoleRequest);
            return Ok(addUserAuthRoleResponse);
        }

        [HttpDelete("DeleteUserAuthRole")]
        [AuthorizeDefinition(Menu = AttributeConst.UserAuthRoles, ActionType = ActionType.Deleting, Definiton = "Delete User Auth Role")]
        public async Task<IActionResult> DeleteUserAuthRole(DeleteUserAuthRoleRequest deleteUserAuthRoleRequest)
        {
            DeleteUserAuthRoleResponse deleteUserAuthRoleResponse = await _mediator.Send(deleteUserAuthRoleRequest);
            return Ok(deleteUserAuthRoleResponse);
        }



        [HttpPut("UpdateUserAuthRole")]
        [AuthorizeDefinition(Menu = AttributeConst.UserAuthRoles, ActionType = ActionType.Updateing, Definiton = "Update User Auth Role")]
        public async Task<IActionResult> UpdateUserAuthRole(UpdateUserAuthRoleRequest updateUserAuthRoleRequest)
        {
            UpdateUserAuthRoleResponse updateUserAuthRoleResponse = await _mediator.Send(updateUserAuthRoleRequest);
            return Ok(updateUserAuthRoleResponse);
        }





    }
}
