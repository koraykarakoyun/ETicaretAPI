using ETicaretAPI.Application.Abstraction.User;
using ETicaretAPI.Application.Abstraction.UserAuthRole;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.UserAuthRole.Command.SetUserAuthRole
{
    public class SetUserAuthRoleHandler : IRequestHandler<SetUserAuthRoleRequest, SetUserAuthRoleResponse>
    {
        IUserAuthRoleService _userAuthRoleService;

        public SetUserAuthRoleHandler(IUserAuthRoleService userAuthRoleService)
        {
            _userAuthRoleService = userAuthRoleService;
        }

        public async Task<SetUserAuthRoleResponse> Handle(SetUserAuthRoleRequest request, CancellationToken cancellationToken)
        {
            bool result = await _userAuthRoleService.SetUserAuthRoleAsync(request.UserId, request.RoleId);

            if (!result)
            {
                throw new Exception("Yetkilendirme Yapıalmadı");
            }
            return new()
            {
                IsSuccess = true,
                Message = "Kullanıcıya Yetki Verilmiştir"
            };

        }
    }
}
