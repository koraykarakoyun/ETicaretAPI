using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.User.Query.GetAllUsers
{
    public class GetAllUsersQueryRequest:IRequest<List<GetAllUsersQueryResponse>>
    {
    }
}
