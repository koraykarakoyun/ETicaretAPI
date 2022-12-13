using ETicaretAPI.Application.Abstraction.User;
using ETicaretAPI.Application.CustomAttributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Reflection;

namespace ETicaretAPI.API.Filters
{
    public class RolePermissionFilter : IAsyncActionFilter
    {
        readonly IUserService _userService;

        public RolePermissionFilter(IUserService userService)
        {
            _userService = userService;

        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var username = context.HttpContext.User.Identity?.Name;

            if(await _userService.IsAdminAsync(username))
            {
                await next();
            }

            else if (!string.IsNullOrEmpty(username))
            {
                

                var descriptor = context.ActionDescriptor as ControllerActionDescriptor;

                var authorizeDefinitionAttribute = descriptor?.MethodInfo.GetCustomAttribute(typeof(AuthorizeDefinitionAttribute)) as AuthorizeDefinitionAttribute;

                var httpAttribute = descriptor?.MethodInfo.GetCustomAttribute(typeof(HttpMethodAttribute)) as HttpMethodAttribute;

                var code = $"{(httpAttribute != null ? httpAttribute.HttpMethods.First() : HttpMethods.Get)}.{authorizeDefinitionAttribute.ActionType}.{authorizeDefinitionAttribute.Definiton.Replace(" ", "")}";

                var hasRole = await _userService.HasRolePermissionToEndpointAsync(username, code);

                if (!hasRole)
                    context.Result = new UnauthorizedResult();
                else
                    await next();

            }
            else
            {
                await next();
            }


        }
    }
}
