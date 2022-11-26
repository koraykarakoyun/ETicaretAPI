﻿using ETicaretAPI.Application.CQRS.AuthorizationEndpoint.Command;
using ETicaretAPI.Application.CQRS.User.Command.Login;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationEndpointsController : ControllerBase
    {

        IMediator _mediator;

        public AuthorizationEndpointsController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost("AssingRoleEndpoint")]
        public async Task<IActionResult> AssingRoleEndpoint(AssingRoleEndpointCommandRequest assingRoleEndpointCommandRequest)
        {
            assingRoleEndpointCommandRequest.Type = typeof(Program);
            AssingRoleEndpointCommandResponse assingRoleEndpointCommandResponse = await _mediator.Send(assingRoleEndpointCommandRequest);
            return Ok(assingRoleEndpointCommandResponse);
        }
    }
}