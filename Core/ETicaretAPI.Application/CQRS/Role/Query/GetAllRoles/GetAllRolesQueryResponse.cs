using ETicaretAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Role.Query.GetAllRoles
{
    public class GetAllRolesQueryResponse
    {
        public List<GetAllRolesDto> Result { get; set; }

    }
}
