using ETicaretAPI.Application.Abstraction.User;
using ETicaretAPI.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.User.Query.GetUserPhoneNumber
{
    public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQueryRequest,GetUserInfoQueryResponse>
    {
        IHttpContextAccessor _contextAccessor;
        IUserService _userService;

        public GetUserInfoQueryHandler(IHttpContextAccessor contextAccessor, IUserService userService)
        {
            _contextAccessor = contextAccessor;
            _userService = userService;
        }

        public async Task<GetUserInfoQueryResponse> Handle(GetUserInfoQueryRequest request, CancellationToken cancellationToken)
        {
            GetUserInfoDto getUserPhoneNumberDto = await _userService.GetUserInfoAsync(_contextAccessor.HttpContext.User.Identity.Name);
            return new GetUserInfoQueryResponse()
            {
                Name = getUserPhoneNumberDto.Name,
                Surname = getUserPhoneNumberDto.Surname,
                PhoneNumber = getUserPhoneNumberDto.PhoneNumber
            };
        }
    }
}
